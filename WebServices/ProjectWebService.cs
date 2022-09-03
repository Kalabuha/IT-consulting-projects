using RepositoryInterfaces;
using ServiceInterfaces;
using EntitiesDataModelsConverters;
using CommonDataConverters;
using WebServices.Common;
using DataModels;

namespace WebServices
{
    internal class ProjectWebService : DefaultDataService, IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectWebService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectData>> GetAllProjectDatasAsync()
        {
            var datas = (await _projectRepository.GetAllProjectEntitiesAsync())
                .Select(p => p.ProjectEntityToData())
                .ToList();

            return datas;
        }

        public async Task<List<ProjectData>> GetPublishedProjectDatasAsync()
        {
            var projects = (await _projectRepository.GetAllProjectEntitiesAsync())
                .Where(p => p.IsPublished == true)
                .Select(p => p.ProjectEntityToData())
                .ToList();

            return projects;
        }

        public async Task<ProjectData?> GetProjectDataByIdAsync(int projectId)
        {
            var project = await _projectRepository.GetEntityAsync(projectId);

            return project?.ProjectEntityToData();
        }

        public async Task AddProjectToDbAsync(ProjectData data)
        {
            if (string.IsNullOrEmpty(data.CustomerCompanyLogoAsString))
            {
                var pathToDefaultCompanyLogo = GetDefaultImageFromFile("retro-wave-logo.png");
                var defaultCompanyLogoAsArray64 = ImageDataConverter.PathToImageToArray64(pathToDefaultCompanyLogo);
                data.CustomerCompanyLogoAsString = Convert.ToBase64String(defaultCompanyLogoAsArray64);
            }

            var entity = data.ProjectDataToEntity();

            await _projectRepository.AddEntityAsync(entity);
        }

        public async Task EditProjectToDbAsync(ProjectData data)
        {
            var entity = await _projectRepository.GetEntityAsync(data.Id);
            if (entity == null) throw new ArgumentException($"Не найден проект {data.Id}.", nameof(data));

            data.ProjectDataToEntity(entity);

            await _projectRepository.UpdateEntityAsync(entity);
        }

        public async Task RemoveProjectToDbAsync(int id)
        {
            await _projectRepository.RemoveEntityAsync(id);
        }
    }
}
