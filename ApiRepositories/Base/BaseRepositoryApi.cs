using System.Net.Http.Json;
using ApiRepositories.Interfaces;
using Entities.Base;

namespace ApiRepositories.Base
{
    public class BaseRepositoryApi<TEntity> : IRepositoryApi<TEntity> where TEntity : BaseEntity
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

        public async Task<bool> AddResourceAsync(TEntity entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_requestUri + "/" + entity.Id.ToString(), entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateResourceAsync(TEntity entity)
        {
            var response = await _httpClient.PutAsJsonAsync(_requestUri + "/" + entity.Id.ToString(), entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteResourceAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_requestUri + "/" + id.ToString());
            return response.IsSuccessStatusCode;
        }
    }
}
