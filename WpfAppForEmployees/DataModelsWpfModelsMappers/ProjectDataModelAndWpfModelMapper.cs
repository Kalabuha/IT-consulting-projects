using System;
using WpfAppForEmployees.WpfModels;
using WpfAppForEmployees.WpfDataConverters;
using DataModels;

namespace WpfAppForEmployees.DataModelsWpfModelsMappers
{
    public static class ProjectDataModelAndWpfModelMapper
    {
        public static ProjectWpfModel ProjectDataModelToWpfModel(this ProjectDataModel data)
        {
            var imageAsString = Convert.ToBase64String(data.CustomerCompanyLogoAsByte);

            return new ProjectWpfModel
            {
                Id = data.Id,
                ProjectTitle = data.ProjectTitle,
                ProjectDescription = data.ProjectDescription,
                IsPublishedAsBool = data.IsPublished,
                LinkToCustomerSite = string.IsNullOrEmpty(data.LinkToCustomerSite) ? "Ссылка не указана" : data.LinkToCustomerSite,
                CustomerCompanyLogoAsBitmap = ImageWpfDataConverter.ConvertImageFromBytesToBitmap(data.CustomerCompanyLogoAsByte)
            };
        }

        public static ProjectDataModel ProjectWpfModelToDataModel(this ProjectWpfModel model)
        {
            //if (model.BlogImageAsBitmap != null)
            //{
            //    var imageAsString = ImageWebDataConverter.ReadBytesFromFormFile(model.BlogImageAsFormFile);
            //    data.BlogImageAsByte = Convert.FromBase64String(imageAsString);
            //}

            var data = new ProjectDataModel
            {
                Id = model.Id,
                ProjectTitle = model.ProjectTitle,
                ProjectDescription = model.ProjectDescription,
                IsPublished = model.IsPublishedAsBool,
                LinkToCustomerSite = model.LinkToCustomerSite,
            };

            return data;
        }
    }
}
