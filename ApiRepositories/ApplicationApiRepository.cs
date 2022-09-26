using ApiRepositories.Base;
using RepositoryInterfaces;
using DataModelsApiModelsMappers;
using DataModels;
using ApiModels;

namespace ApiRepositories
{
    public class ApplicationApiRepository : BaseApiRepository<ApplicationApiModel>, IApplicationRepository
    {
        public ApplicationApiRepository(HttpClient httpClient) : base(httpClient, "api/Applications") { }

        public async Task<ApplicationDataModel?> GetApplicationAsync(int id)
        {
            var api = await GetEntityAsync(id);
            return api?.ApplicationApiToData();
        }

        public async Task<ApplicationDataModel[]> GetAllApplicationAsync()
        {
            var datas = (await GetEntitiesAsync())
                .Select(a => a.ApplicationApiToData())
                .ToArray();

            return datas;
        }

        public async Task<int> AddApplicationAsync(ApplicationDataModel data)
        {
            var api = data.ApplicationDataToApi();

            if (await AddEntityAsync(api))
            {
                return data.Number;
            }

            return 0;
        }

        public async Task<bool> UpdateApplicationAsync(ApplicationDataModel data)
        {
            var api = data.ApplicationDataToApi();
            return await UpdateEntityAsync(api);
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            return await RemoveEntityAsync(id);
        }
    }
}
