using ApiRepositories.Base;
using RepositoryInterfaces;
using DataModelsApiModelsMappers;
using DataModels;
using ApiModels;

namespace ApiRepositories
{
    internal class ServiceApiRepository : BaseApiRepository<ServiceApiModel>, IServiceRepository
    {
        public ServiceApiRepository(HttpClient httpClient) : base(httpClient, "api/Services") { }

        public async Task<ServiceDataModel?> GetServiceAsync(int id)
        {
            var api = await GetEntityAsync(id);
            return api?.ServiceApiToData();
        }

        public async Task<ServiceDataModel[]> GetAllServiceAsync()
        {
            var datas = (await GetEntitiesAsync())
                .Select(s => s.ServiceApiToData())
                .ToArray();

            return datas;
        }

        public async Task<int> AddServiceAsync(ServiceDataModel data)
        {
            var api = data.ServiceDataToApi();

            if (await AddEntityAsync(api))
            {
                return data.Id;
            }

            return 0;
        }

        public async Task<bool> UpdateServiceAsync(ServiceDataModel data)
        {
            var api = data.ServiceDataToApi();
            return await UpdateEntityAsync(api);
        }

        public async Task<bool> DeleteServiceAsync(int id)
        {
            return await RemoveEntityAsync(id);
        }
    }
}
