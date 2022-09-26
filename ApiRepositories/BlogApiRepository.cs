using ApiRepositories.Base;
using RepositoryInterfaces;
using DataModelsApiModelsMappers;
using DataModels;
using ApiModels;

namespace ApiRepositories
{
    internal class BlogApiRepository : BaseApiRepository<BlogApiModel>, IBlogRepository
    {
        public BlogApiRepository(HttpClient httpClient) : base(httpClient, "api/Blogs") {}

        public async Task<BlogDataModel?> GetBlogAsync(int id)
        {
            var api = await GetEntityAsync(id);
            return api?.BlogApiToData();
        }

        public async Task<BlogDataModel[]> GetAllBlogsAsync()
        {
            var datas = (await GetEntitiesAsync())
                .Select(b => b.BlogApiToData())
                .ToArray();

            return datas;
        }

        public async Task<int> AddBlogAsync(BlogDataModel data)
        {
            var api = data.BlogDataToApi();

            if (await AddEntityAsync(api))
            {
                return data.Id;
            }

            return 0;
        }

        public async Task<bool> UpdateBlogAsync(BlogDataModel data)
        {
            var api = data.BlogDataToApi();
            return await UpdateEntityAsync(api);
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            return await RemoveEntityAsync(id);
        }
    }
}
