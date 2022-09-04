using System.Net.Http.Json;
using ApiRepositories.Base;
using RepositoryInterfaces;
using Entities;

namespace ApiRepositories
{
    internal class ServiceApiRepository : BaseApiRepository<ServiceEntity>, IServiceRepository
    {
        public ServiceApiRepository(HttpClient httpClient) : base(httpClient, "api/Services") { }

        public async Task<ServiceEntity[]> GetAllServiceEntitiesAsync()
        {
            var services = await _httpClient.GetFromJsonAsync<ServiceEntity[]>(_requestUri);
            services ??= new ServiceEntity[0];
            return services;
        }
    }
}
