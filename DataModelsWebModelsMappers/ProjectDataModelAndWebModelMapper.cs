using DataModels;
using WebModels;
using WebDataConverters;

namespace DataModelsWebModelsMappers
{
    public static class ProjectDataModelAndWebModelMapper
    {
        public static ProjectWebModel ProjectDataToModel(this ProjectDataModel data)
        {
            var imageAsString = Convert.ToBase64String(data.CustomerCompanyLogoAsByte);

            return new ProjectWebModel
            {
                Id = data.Id,
                ProjectTitle = data.ProjectTitle,
                ProjectDescription = data.ProjectDescription,
                IsPublished = data.IsPublished,
                LinkToCustomerSite = data.LinkToCustomerSite,
                CustomerCompanyLogoAsDataImage = string.Format("data:image/jpg;base64,{0}", imageAsString)
            };
        }

        public static ProjectDataModel ProjectModelToData(this ProjectWebModel model)
        {
            var data = new ProjectDataModel
            {
                Id = model.Id,
                ProjectTitle = model.ProjectTitle,
                ProjectDescription = model.ProjectDescription,
                IsPublished = model.IsPublished,
                LinkToCustomerSite = model.LinkToCustomerSite,
            };

            if (model.CustomerCompanyLogoAsFormFile != null)
            {
                var imageAsString = ImageWebDataConverter.ConvertImageFromFormFileToBytes(model.CustomerCompanyLogoAsFormFile);
                data.CustomerCompanyLogoAsByte = Convert.FromBase64String(imageAsString);
            }
            else
            {
                data.CustomerCompanyLogoAsByte = new byte[0];
            }

            return data;
        }
    }
}
