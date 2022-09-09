using WpfAppForEmployees.WpfModels;
using WpfAppForEmployees.WpfDataConverters;
using DataModels;

namespace WpfAppForEmployees.DataModelsWpfModelsMappers
{
    public static class BlogDataModelAndWpfModelMapper
    {
        public static BlogWpfModel BlogDataModelToWpfModel(this BlogDataModel data)
        {
            var imageAsBitmap = data.BlogImageAsByte != null ? ImageWpfDataConverter.ConvertImageFromBytesToBitmap(data.BlogImageAsByte) : null;

            return new BlogWpfModel
            {
                Id = data.Id,
                BlogTitle = data.BlogTitle,
                ShortBlogDescription = data.ShortBlogDescription,
                LongBlogDescription = data.LongBlogDescription,
                PublicationDateAsDateTime = data.PublicationDate,
                BlogImageAsBitmap = imageAsBitmap,
                IsPublishedAsBool = data.IsPublished
            };
        }

        public static BlogDataModel BlogWpfModelToDataModel(this BlogWpfModel model)
        {
            //if (model.BlogImageAsBitmap != null)
            //{
            //    var imageAsString = ImageWebDataConverter.ReadBytesFromFormFile(model.BlogImageAsFormFile);
            //    data.BlogImageAsByte = Convert.FromBase64String(imageAsString);
            //}

            var data = new BlogDataModel
            {
                Id = model.Id,
                BlogTitle = model.BlogTitle,
                ShortBlogDescription = model.ShortBlogDescription,
                LongBlogDescription = model.LongBlogDescription,
            };

            return data;
        }
    }
}
