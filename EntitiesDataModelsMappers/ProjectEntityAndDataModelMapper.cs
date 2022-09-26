using DataModels;
using Entities;

namespace EntitiesDataModelsMappers
{
    public static class ProjectEntityAndDataModelMapper
    {
        public static ProjectDataModel ProjectEntityToData(ProjectEntity entity)
        {
            return new ProjectDataModel
            {
                Id = entity.Id,
                ProjectTitle = entity.Title,
                LinkToCustomerSite = entity.LinkToCustomerSite ?? string.Empty,
                ProjectDescription = entity.ProjectDescription,
                CustomerCompanyLogoAsByte = entity.CustomerCompanyLogoAsArray64,
                IsPublished = entity.IsPublished
            };
        }

        public static ProjectEntity ProjectDataToEntity(ProjectDataModel data, ProjectEntity? entity = null)
        {
            entity ??= new ProjectEntity();

            entity.Title = data.ProjectTitle;
            entity.LinkToCustomerSite =
                string.IsNullOrEmpty(data.LinkToCustomerSite) || string.IsNullOrWhiteSpace(data.LinkToCustomerSite) ? null : data.LinkToCustomerSite;
            
            entity.ProjectDescription = data.ProjectDescription;
            entity.IsPublished = data.IsPublished;

            if(data.CustomerCompanyLogoAsByte != null && data.CustomerCompanyLogoAsByte.Length > 0)
            {
                entity.CustomerCompanyLogoAsArray64 = data.CustomerCompanyLogoAsByte;
            }

            return entity;
        }
    }
}
