using System.Net.Http.Json;
using ApiRepositories.Base;
using RepositoryInterfaces;
using Entities;

namespace ApiRepositories
{
    public class ProjectApiRepository : BaseApiRepository<ProjectEntity>
    {
        public ProjectApiRepository(HttpClient httpClient) : base(httpClient, "api/Projects") {}

        public async Task<ProjectEntity[]> GetAllEntitiesAsync()
        {
            var projects = await _httpClient.GetFromJsonAsync<ProjectEntity[]>(_requestUri);
            projects ??= new ProjectEntity[0];
            return projects;
        }
    }
}
