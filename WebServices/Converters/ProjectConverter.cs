using Entities;
using WebModels;
using DataModels;

namespace WebServices.Converters
{
    public static class ProjectConverter
    {
        public static ProjectData ProjectEntityToData(this ProjectEntity entity)
        {
            return new ProjectData
            {
                Id = entity.Id,
                ProjectTitle = entity.Title,
                LinkToCustomerSite = entity.LinkToCustomerSite ?? string.Empty,
                ProjectDescription = entity.ProjectDescription,
                CustomerCompanyLogoAsString = Convert.ToBase64String(entity.CustomerCompanyLogoAsArray64),
                IsPublished = entity.IsPublished
            };
        }

        public static ProjectEntity ProjectDataToEntity(this ProjectData data, ProjectEntity? entity = null)
        {
            entity ??= new ProjectEntity();

            entity.Title = data.ProjectTitle;
            entity.LinkToCustomerSite =
                string.IsNullOrEmpty(data.LinkToCustomerSite) || string.IsNullOrWhiteSpace(data.LinkToCustomerSite) ? null : data.LinkToCustomerSite;
            
            entity.ProjectDescription = data.ProjectDescription;
            entity.IsPublished = data.IsPublished;

            if(!string.IsNullOrEmpty(data.CustomerCompanyLogoAsString))
            {
                entity.CustomerCompanyLogoAsArray64 = Convert.FromBase64String(data.CustomerCompanyLogoAsString);
            }

            return entity;
        }

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
                data.CustomerCompanyLogoAsString = CommonDataConverter.ReadBytesFromFormFile(model.CustomerCompanyLogoAsFormFile);
            }

            return data;
        }
    }
}
