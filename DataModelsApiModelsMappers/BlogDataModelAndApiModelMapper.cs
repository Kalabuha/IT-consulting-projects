using DataModels;
using ApiModels;

namespace DataModelsApiModelsMappers
{
    public static class BlogDataModelAndApiModelMapper
    {
        public static BlogApiModel BlogDataToApi(this BlogDataModel data)
        {
            return new BlogApiModel
            {
                Id = data.Id,
                BlogTitle = data.BlogTitle,
                ShortBlogDescription = data.ShortBlogDescription,
                LongBlogDescription = data.LongBlogDescription,
                BlogImageAsByte = data.BlogImageAsByte,
                IsPublished = data.IsPublished
            };
        }

        public static BlogDataModel BlogApiToData(this BlogApiModel api)
        {
            return new BlogDataModel
            {
                Id = api.Id,
                BlogTitle = api.BlogTitle ?? string.Empty,
                ShortBlogDescription = api.ShortBlogDescription ?? string.Empty,
                LongBlogDescription = api.LongBlogDescription ?? string.Empty,
                IsPublished = api.IsPublished ?? false,
            };
        }
    }
}
