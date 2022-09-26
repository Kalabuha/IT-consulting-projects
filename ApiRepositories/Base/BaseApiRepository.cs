using System.Net.Http.Json;
using ApiModels.Base;

namespace ApiRepositories.Base
{
    public abstract class BaseApiRepository<TApiModel> where TApiModel : BaseApiModel
    {
        protected readonly string _requestUri;
        protected readonly HttpClient _httpClient;

        public BaseApiRepository(HttpClient httpClient, string requestUri)
        {
            _requestUri = requestUri;
            _httpClient = httpClient;
        }

        public async Task<TApiModel[]> GetEntitiesAsync()
        {
            var apiModels = await _httpClient.GetFromJsonAsync<TApiModel[]>(_requestUri)
                ?? Array.Empty<TApiModel>();

            return apiModels;
        }

        public async Task<TApiModel?> GetEntityAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TApiModel>(_requestUri + "/" + id);
        }

        public async Task<bool> AddEntityAsync(TApiModel entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_requestUri + "/" + entity.Id, entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEntityAsync(TApiModel entity)
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
