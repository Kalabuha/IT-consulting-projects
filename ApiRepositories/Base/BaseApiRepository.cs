using System.Net.Http.Json;
using DataModels.Base;

namespace ApiRepositories.Base
{
    public abstract class BaseApiRepository<TData> where TData : BaseDataModel
    {
        protected readonly string _requestUri;
        protected readonly HttpClient _httpClient;

        public BaseApiRepository(HttpClient httpClient, string requestUri)
        {
            _requestUri = requestUri;
            _httpClient = httpClient;
        }

        public async Task<TData?> GetEntityAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TData>(_requestUri + "/" + id);
        }

        public async Task<bool> AddEntityAsync(TData entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_requestUri + "/" + entity.Id, entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEntityAsync(TData entity)
        {
            var response = await _httpClient.PutAsJsonAsync(_requestUri + "/" + entity.Id, entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveEntityAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(_requestUri + "/" + id);
            return response.IsSuccessStatusCode;
        }
    }
}
