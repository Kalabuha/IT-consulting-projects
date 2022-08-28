using Resources.Entities;
using ResourcesApi;

namespace ServicesApi.Converters
{
    public static class ProjectConverterApi
    {
        public static ProjectResource ProjectEntityToResource(this ProjectEntity entity)
        {
            return new ProjectResource
            {
                Id = entity.Id,
                ProjectTitle = entity.Title,
                LinkToCustomerSite = entity.LinkToCustomerSite ?? string.Empty,
                ProjectDescription = entity.ProjectDescription,
                CustomerCompanyLogoAsString = Convert.ToBase64String(entity.CustomerCompanyLogoAsArray64),
                IsPublished = entity.IsPublished
            };
        }

        public static ProjectEntity ProjectResourceToEntity(this ProjectResource data, ProjectEntity? entity = null)
        {
            entity ??= new ProjectEntity();

            entity.Title = data.ProjectTitle;
            entity.LinkToCustomerSite =
                string.IsNullOrEmpty(data.LinkToCustomerSite) || string.IsNullOrWhiteSpace(data.LinkToCustomerSite) ? null : data.LinkToCustomerSite;

            entity.ProjectDescription = data.ProjectDescription;
            entity.IsPublished = data.IsPublished;

            if (!string.IsNullOrEmpty(data.CustomerCompanyLogoAsString))
            {
                entity.CustomerCompanyLogoAsArray64 = Convert.FromBase64String(data.CustomerCompanyLogoAsString);
            }

            return entity;
        }
    }
}
