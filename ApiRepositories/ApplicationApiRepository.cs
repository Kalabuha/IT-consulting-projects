using System.Net.Http.Json;
using ApiRepositories.Base;
using RepositoryInterfaces;
using DataModels;

namespace ApiRepositories
{
    public class ApplicationApiRepository : BaseApiRepository<ApplicationDataModel>, IApplicationRepository
    {
        public ApplicationApiRepository(HttpClient httpClient) : base(httpClient, "api/Applications") { }

        public async Task<ApplicationDataModel?> GetApplicationAsync(int id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<ApplicationDataModel[]> GetAllApplicationAsync()
        {
            var applications = await _httpClient.GetFromJsonAsync<ApplicationDataModel[]>(_requestUri);
            applications ??= Array.Empty<ApplicationDataModel>();
            return applications;
        }

        public async Task<int> AddApplicationAsync(ApplicationDataModel data)
        {
            if (await AddEntityAsync(data))
            {
                return data.Number;
            }

            return 0;
        }

        public async Task<bool> UpdateApplicationAsync(ApplicationDataModel data)
        {
            return await UpdateEntityAsync(data);
        }

        public async Task<bool> DeleteApplicationAsync(int id)
        {
            return await RemoveEntityAsync(id);
        }
    }
}
