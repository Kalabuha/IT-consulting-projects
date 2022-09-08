using System;
using WpfAppForEmployees.WpfModels;
using WpfAppForEmployees.WpfDataConverters;
using DataModels;

namespace WpfAppForEmployees.DataModelsWpfModelsMappers
{
    public static class ProjectDataModelAndWpfModelMapper
    {
        public static ProjectWpfModel ProjectDataToModel(this ProjectDataModel data)
        {
            var imageAsString = Convert.ToBase64String(data.CustomerCompanyLogoAsByte);

            return new ProjectWpfModel
            {
                Id = data.Id,
                ProjectTitle = data.ProjectTitle,
                ProjectDescription = data.ProjectDescription,
                IsPublished = data.IsPublished,
                LinkToCustomerSite = data.LinkToCustomerSite,
                CustomerCompanyLogoAsBitmap = ImageWpfDataConverter.ConvertImageFromBytesToBitmap(data.CustomerCompanyLogoAsByte)
            };
        }

        public static ProjectDataModel ProjectModelToData(this ProjectWpfModel model)
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
                IsPublished = model.IsPublished,
                LinkToCustomerSite = model.LinkToCustomerSite,
            };

            return data;
        }
    }
}
