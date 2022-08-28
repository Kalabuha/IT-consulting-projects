using System.Net.Http.Json;
using RepositoriesApi.Interfaces;
using ResourcesApi.Base;
using Resources.Entities.Base;

namespace RepositoriesApi.Base
{
    public class BaseRepositoryApi<TEntity, TResource> : IRepositoryApi<TEntity, TResource>
        where TEntity : BaseEntity
        where TResource : BaseResource
    {
        protected readonly HttpClient _httpClient;
        private readonly string _requestUri;

        public BaseRepositoryApi(HttpClient httpClient, string requestUri)
        {
            _requestUri = requestUri;
            _httpClient = httpClient;
        }

        public async Task<TEntity[]?> GetAllResources()
        {
            var projects = await _httpClient.GetFromJsonAsync<TEntity[]>(_requestUri);
            return projects;
        }

        public async Task<TEntity?> GetResource(int id)
        {
            var resource = await _httpClient.GetFromJsonAsync<TEntity>(_requestUri + "/" + id.ToString());
            return resource;
        }

        public async Task<bool> AddResourceAsync(TResource resource)
        {
            var response = await _httpClient.PostAsJsonAsync(_requestUri + "/" + resource.Id.ToString(), resource);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateResourceAsync(TResource resource)
        {
            var response = await _httpClient.PutAsJsonAsync(_requestUri + "/" + resource.Id.ToString(), resource);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteResourceAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_requestUri + "/" + id.ToString());
            return response.IsSuccessStatusCode;
        }
    }
}
