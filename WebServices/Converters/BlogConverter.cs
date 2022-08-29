using Entities;
using WebModels;
using DataModels;

namespace WebServices.Converters
{
    public static class BlogConverter
    {
        public static BlogData BlogEntityToData(this BlogEntity entity)
        {
            return new BlogData
            {
                Id = entity.Id,
                BlogTitle = entity.Title,
                ShortBlogDescription = entity.ShortBlogDescription,
                LongBlogDescription = entity.LongBlogDescription,
                BlogImageAsString = entity.BlogImageAsArray64 != null ? Convert.ToBase64String(entity.BlogImageAsArray64) : null,
                PublicationDate = entity.PublicationDate,
                IsPublished = entity.IsPublished,
            };
        }

        public static BlogEntity BlogDataToEntity(this BlogData data, BlogEntity? entity = null)
        {
            entity ??= new BlogEntity();

            if (data.BlogImageAsString != string.Empty)
            {
                if (data.BlogImageAsString == null)
                {
                    entity.BlogImageAsArray64 = null;
                }
                else
                {
                    entity.BlogImageAsArray64 = Convert.FromBase64String(data.BlogImageAsString);
                }
            }

            entity.Id = data.Id;
            entity.Title = data.BlogTitle;
            entity.ShortBlogDescription = data.ShortBlogDescription;
            entity.LongBlogDescription = data.LongBlogDescription;
            entity.PublicationDate = data.PublicationDate;
            entity.IsPublished = data.IsPublished;

            return entity;
        }

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
                data.BlogImageAsString = CommonDataConverter.ReadBytesFromFormFile(model.BlogImageAsFormFile);
            }

            return data;
        }
    }
}
