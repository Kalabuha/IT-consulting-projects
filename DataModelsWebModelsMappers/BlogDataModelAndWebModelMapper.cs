using DataModels;
using WebModels;
using WebDataConverters;

namespace DataModelsWebModelsMappers
{
    public static class BlogDataModelAndWebModelMapper
    {
        public static BlogWebModel BlogDataToModel(this BlogDataModel data)
        {
            var imageAsString = data.BlogImageAsByte != null ? Convert.ToBase64String(data.BlogImageAsByte) : null;

            return new BlogWebModel
            {
                Id = data.Id,
                BlogTitle = data.BlogTitle,
                ShortBlogDescription = data.ShortBlogDescription,
                LongBlogDescription = data.LongBlogDescription,
                PublicationDate = data.PublicationDate,
                BlogImageAsString = string.IsNullOrEmpty(imageAsString) ? null : string.Format("data:image/jpg;base64,{0}", imageAsString),
                IsPublished = data.IsPublished
            };
        }

        public static BlogDataModel BlogModelToData(this BlogWebModel model)
        {
            var data = new BlogDataModel
            {
                Id = model.Id,
                BlogTitle = model.BlogTitle,
                ShortBlogDescription = model.ShortBlogDescription,
                LongBlogDescription = model.LongBlogDescription,
                PublicationDate = model.PublicationDate,
                IsPublished = model.IsPublished,
            };

            if (model.BlogImageAsFormFile != null)
            {
                var imageAsString = ImageWebDataConverter.ConvertImageFromFormFileToBytes(model.BlogImageAsFormFile);
                data.BlogImageAsByte = Convert.FromBase64String(imageAsString);
            }

            return data;
        }
    }
}
