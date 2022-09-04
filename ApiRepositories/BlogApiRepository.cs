using System.Net.Http.Json;
using ApiRepositories.Base;
using RepositoryInterfaces;
using Entities;

namespace ApiRepositories
{
    internal class BlogApiRepository : BaseApiRepository<BlogEntity>, IBlogRepository
    {
        public BlogApiRepository(HttpClient httpClient) : base(httpClient, "api/Blogs") {}

        public async Task<BlogEntity[]> GetAllBlogEntitiesAsync()
        {
            var blogs = await _httpClient.GetFromJsonAsync<BlogEntity[]>(_requestUri);
            blogs ??= new BlogEntity[0];
            return blogs;
        }
    }
}
