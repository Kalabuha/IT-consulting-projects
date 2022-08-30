using DataModels;
using WebModels;
using WebDataConverters;

namespace DataModelsWebModelsConverters
{
    public static class ProjectDataModelAndWebModelConverter
    {
        public static ProjectModel ProjectDataToModel(this ProjectData data)
        {
            return new ProjectModel
            {
                Id = data.Id,
                ProjectTitle = data.ProjectTitle,
                ProjectDescription = data.ProjectDescription,
                IsPublished = data.IsPublished,
                LinkToCustomerSite = data.LinkToCustomerSite,
                CustomerCompanyLogoAsDataImage = string.Format("data:image/jpg;base64,{0}", data.CustomerCompanyLogoAsString)
            };
        }

        public static ProjectData ProjectModelToData(this ProjectModel model)
        {
            var data = new ProjectData
            {
                Id = model.Id,
                ProjectTitle = model.ProjectTitle,
                ProjectDescription = model.ProjectDescription,
                IsPublished = model.IsPublished,
                LinkToCustomerSite = model.LinkToCustomerSite,
            };

            if (model.CustomerCompanyLogoAsFormFile != null)
            {
                data.CustomerCompanyLogoAsString = ImageWebDataConverter.ReadBytesFromFormFile(model.CustomerCompanyLogoAsFormFile);
            }

            return data;
        }
    }
}
