using System.Net.Http.Json;
using RepositoryInterfaces;
using Entities.Base;

namespace ApiRepositories.Base
{
    public abstract class BaseApiRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly string _requestUri;
        protected readonly HttpClient _httpClient;

        public BaseApiRepository(HttpClient httpClient, string requestUri)
        {
            _requestUri = requestUri;
            _httpClient = httpClient;
        }

        public async Task<TEntity?> GetEntityAsync(int? id)
        {
            return id.HasValue ? await _httpClient.GetFromJsonAsync<TEntity>(_requestUri + "/" + id.ToString()) : null;
        }

        public async Task<bool> AddEntityAsync(TEntity entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_requestUri + "/" + entity.Id.ToString(), entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEntityAsync(TEntity entity)
        {
            var response = await _httpClient.PutAsJsonAsync(_requestUri + "/" + entity.Id.ToString(), entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveEntityAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_requestUri + "/" + id.ToString());
            return response.IsSuccessStatusCode;
        }
    }
}
