using Entities;
using DataModels;

namespace EntitiesDataModelsMappers
{
    public static class BlogEntityAndDataModelMapper
    {
        public static BlogDataModel BlogEntityToData(this BlogEntity entity)
        {
            return new BlogDataModel
            {
                Id = entity.Id,
                BlogTitle = entity.Title,
                ShortBlogDescription = entity.ShortBlogDescription,
                LongBlogDescription = entity.LongBlogDescription,
                BlogImageAsByte = entity.BlogImageAsArray64 != null ? entity.BlogImageAsArray64 : null,
                PublicationDate = entity.PublicationDate,
                IsPublished = entity.IsPublished,
            };
        }

        public static BlogEntity BlogDataToEntity(this BlogDataModel data, BlogEntity? entity = null)
        {
            entity ??= new BlogEntity();

            if (data.BlogImageAsByte != null)
            {
                if (data.BlogImageAsByte.Length > 0)
                {
                    entity.BlogImageAsArray64 = data.BlogImageAsByte;
                }
            }
            else
            {
                entity.BlogImageAsArray64 = null;
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
