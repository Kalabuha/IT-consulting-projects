using System.Net.Http.Json;
using ApiRepositories.Base;
using RepositoryInterfaces;
using DataModels;

namespace ApiRepositories
{
    internal class ProjectApiRepository : BaseApiRepository<ProjectDataModel>, IProjectRepository
    {
        public ProjectApiRepository(HttpClient httpClient) : base(httpClient, "api/Projects") {}

        public async Task<ProjectDataModel?> GetProjectAsync(int id)
        {
            return await GetEntityAsync(id);
        }

        public async Task<ProjectDataModel[]> GetAllProjectsAsync()
        {
            var projects = await _httpClient.GetFromJsonAsync<ProjectDataModel[]>(_requestUri);
            projects ??= Array.Empty<ProjectDataModel>();
            return projects;
        }

        public async Task<int> AddProjectAsync(ProjectDataModel data)
        {
            if (await AddEntityAsync(data))
            {
                return data.Id;
            }

            return 0;
        }

        public async Task<bool> UpdateProjectAsync(ProjectDataModel data)
        {
            return await UpdateEntityAsync(data);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await RemoveEntityAsync(id);
        }
    }
}
