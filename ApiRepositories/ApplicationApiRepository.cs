using System.Net.Http.Json;
using ApiRepositories.Base;
using RepositoryInterfaces;
using Entities;

namespace ApiRepositories
{
    public class ApplicationApiRepository : BaseApiRepository<ApplicationEntity>, IApplicationRepository
    {
        public ApplicationApiRepository(HttpClient httpClient) : base(httpClient, "api/Applications") {}

        public async Task<ApplicationEntity[]> GetAllApplicationEntitiesAsync()
        {
            var applications = await _httpClient.GetFromJsonAsync<ApplicationEntity[]>(_requestUri);
            applications ??= new ApplicationEntity[0];
            return applications;
        }
    }
}
