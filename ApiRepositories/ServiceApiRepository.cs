using System.Net.Http.Json;
using ApiRepositories.Base;
using RepositoryInterfaces;
using Entities;
using DataModels;

namespace ApiRepositories
{
    internal class ServiceApiRepository : BaseApiRepository<ServiceDataModel>, IServiceRepository
    {
        public ServiceApiRepository(HttpClient httpClient) : base(httpClient, "api/Services") { }

        public async Task<ServiceDataModel?> GetServiceAsync(int id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<ServiceDataModel[]> GetAllServiceAsync()
        {
            var services = await _httpClient.GetFromJsonAsync<ServiceDataModel[]>(_requestUri);
            services ??= Array.Empty<ServiceDataModel>();
            return services;
        }

        public async Task<int> AddServiceAsync(ServiceDataModel data)
        {
            if (await AddEntityAsync(data))
            {
                return data.Id;
            }

            return 0;
        }

        public async Task<bool> UpdateServiceAsync(ServiceDataModel data)
        {
            return await UpdateEntityAsync(data);
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            return await RemoveEntityAsync(id);
        }
    }
}
