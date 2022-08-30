using Entities;
using DataModels;

namespace EntitiesDataModelsConverters
{
    public static class BlogEntityAndDataModelConverter
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
    }
}
