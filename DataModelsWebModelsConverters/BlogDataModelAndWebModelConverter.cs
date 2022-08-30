using DataModels;
using WebModels;
using WebDataConverters;

namespace DataModelsWebModelsConverters
{
    public static class BlogDataModelAndWebModelConverter
    {
        public static BlogModel BlogDataToModel(this BlogData data)
        {
            return new BlogModel
            {
                Id = data.Id,
                BlogTitle = data.BlogTitle,
                ShortBlogDescription = data.ShortBlogDescription,
                LongBlogDescription = data.LongBlogDescription,
                PublicationDate = data.PublicationDate,
                BlogImageAsString = string.IsNullOrEmpty(data.BlogImageAsString) ? null : string.Format("data:image/jpg;base64,{0}", data.BlogImageAsString),
                IsPublished = data.IsPublished
            };
        }

        public static BlogData BlogModelToData(this BlogModel model)
        {
            var data = new BlogData
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
                data.BlogImageAsString = ImageWebDataConverter.ReadBytesFromFormFile(model.BlogImageAsFormFile);
            }

            return data;
        }
    }
}
