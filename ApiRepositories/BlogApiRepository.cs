using System.Net.Http.Json;
using ApiRepositories.Base;
using RepositoryInterfaces;
using DataModels;

namespace ApiRepositories
{
    internal class BlogApiRepository : BaseApiRepository<BlogDataModel>, IBlogRepository
    {
        public BlogApiRepository(HttpClient httpClient) : base(httpClient, "api/Blogs") {}

        public async Task<BlogDataModel?> GetBlogAsync(int id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<BlogDataModel[]> GetAllBlogsAsync()
        {
            var blogs = await _httpClient.GetFromJsonAsync<BlogDataModel[]>(_requestUri);
            blogs ??= Array.Empty<BlogDataModel>();
            return blogs;
        }

        public async Task<int> AddBlogAsync(BlogDataModel data)
        {
            if (await AddEntityAsync(data))
            {
                return data.Id;
            }

            return 0;
        }

        public async Task<bool> UpdateBlogAsync(BlogDataModel data)
        {
            return await UpdateEntityAsync(data);
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            return await RemoveEntityAsync(id);
        }
    }
}
