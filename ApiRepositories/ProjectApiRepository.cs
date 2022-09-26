using ApiRepositories.Base;
using RepositoryInterfaces;
using DataModelsApiModelsMappers;
using DataModels;
using ApiModels;

namespace ApiRepositories
{
    internal class ProjectApiRepository : BaseApiRepository<ProjectApiModel>, IRepository
    {
        public ProjectApiRepository(HttpClient httpClient) : base(httpClient, "api/Projects") {}

        public async Task<ProjectDataModel?> GetProjectAsync(int id)
        {
            var api = await GetEntityAsync(id);
            return api?.ProjectApiToData();
        }

        public async Task<ProjectDataModel[]> GetAllProjectsAsync()
        {
            var datas = (await GetEntitiesAsync())
                .Select(p => p.ProjectApiToData())
                .ToArray();

            return datas;
        }

        public async Task<int> AddProjectAsync(ProjectDataModel data)
        {
            var api = data.ProjectDataToApi();

            if (await AddEntityAsync(api))
            {
                return data.Id;
            }

            return 0;
        }

        public async Task<bool> UpdateProjectAsync(ProjectDataModel data)
        {
            var api = data.ProjectDataToApi();
            return await UpdateEntityAsync(api);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await RemoveEntityAsync(id);
        }
    }
}
