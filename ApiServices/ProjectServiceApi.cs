using ApiServices.Interfaces;
using ApiServices.Converters;
using ApiRepositories;
using DataModels;

namespace ApiServices
{
    internal class ProjectServiceApi : IProjectServiceApi
    {
        private readonly ProjectRepositoryApi _projectRepositoryApi;

        public ProjectServiceApi(ProjectRepositoryApi projectRepositoryApi)
        {
            _projectRepositoryApi = projectRepositoryApi;
        }

        public async Task<List<ProjectResource>> GetAllProjectResourcesAsync()
        {
            var resources = (await _projectRepositoryApi.GetAllResources())
                .Select(p => p.ProjectEntityToData())
                .ToList();

            return resources;
        }

        public async Task<List<ProjectData>> GetPublishedProjectResourcesAsync()
        {
            var projects = (await _projectRepository.GetAllProjectEntitiesAsync())
                .Where(p => p.IsPublished == true)
                .Select(p => p.ProjectEntityToData())
                .ToList();

            return projects;
        }

        public async Task<ProjectData?> GetProjectResourcesByIdAsync(int projectId)
        {
            var project = await _projectRepository.GetEntity(projectId);

            return project?.ProjectEntityToData();
        }

        public async Task AddProjectToDbAsync(ProjectData data)
        {
            if (string.IsNullOrEmpty(data.CustomerCompanyLogoAsString))
            {
                var pathToDefaultCompanyLogo = GetDefaultImageFromFile("retro-wave-logo.png");
                var defaultCompanyLogoAsArray64 = DataConverter.PathToImageToArray64(pathToDefaultCompanyLogo);
                data.CustomerCompanyLogoAsString = Convert.ToBase64String(defaultCompanyLogoAsArray64);
            }

            var entity = data.ProjectDataToEntity();

            await _projectRepository.AddEntityAsync(entity);
        }

        public async Task EditProjectToDbAsync(ProjectData data)
        {
            var entity = await _projectRepository.GetEntity(data.Id);
            if (entity == null) throw new ArgumentException($"Не найден проект {data.Id}.", nameof(data));

            data.ProjectDataToEntity(entity);

            await _projectRepository.UpdateEntityAsync(entity);
        }

        public async Task RemoveProjectToDbAsync(int id)
        {
            var entity = await _projectRepository.GetEntity(id);
            if (entity != null)
            {
                await _projectRepository.RemoveEntityAsync(entity);
            }
        }
    }
}
