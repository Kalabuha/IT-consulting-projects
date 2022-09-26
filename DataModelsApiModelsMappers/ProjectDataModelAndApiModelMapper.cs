using DataModels;
using ApiModels;

namespace DataModelsApiModelsMappers
{
    public static class ProjectDataModelAndApiModelMapper
    {
        public static ProjectApiModel ProjectDataToApi(this ProjectDataModel data)
        {
            return new ProjectApiModel
            {
                Id = data.Id,
                ProjectTitle = data.ProjectTitle,
                ProjectDescription = data.ProjectDescription,
                LinkToCustomerSite = data.LinkToCustomerSite,
                CustomerCompanyLogoAsByte = data.CustomerCompanyLogoAsByte,
                IsPublished = data.IsPublished,
            };
        }

        public static ProjectDataModel ProjectApiToData(this ProjectApiModel api)
        {
            return new ProjectDataModel
            {
                Id = api.Id,
                ProjectTitle = api.ProjectTitle ?? string.Empty,
                ProjectDescription = api.ProjectDescription ?? string.Empty,
                LinkToCustomerSite = api.LinkToCustomerSite,
                CustomerCompanyLogoAsByte = api.CustomerCompanyLogoAsByte ?? Array.Empty<byte>(),
                IsPublished = api.IsPublished ?? false,
            };
        }
    }
}
