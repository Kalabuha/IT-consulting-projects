using RepositoryInterfaces;
using ServiceInterfaces;
using DefaultDataServices;
using CommonDataConverters;
using DataModels;

namespace ContentDataServices
{
    internal class ProjectDataService : DefaultDataService, IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectDataService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDataModel>> GetAllProjectDatasAsync()
        {
            var datas = (await _projectRepository.GetAllProjectsAsync())
                .ToList();

            return datas;
        }

        public async Task<List<ProjectDataModel>> GetPublishedProjectDatasAsync()
        {
            var projects = (await _projectRepository.GetAllProjectsAsync())
                .Where(p => p.IsPublished)
                .ToList();

            return projects;
        }

        public async Task<ProjectDataModel?> GetProjectDataByIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectAsync(id);

            return project;
        }

        // Для Db репозитория - перед сохранением необходимо убедится, что есть картинка и добавить её если она отстутствует.
        public async Task AddProjectToDbAsync(ProjectDataModel? data, string startPathToDefaultData)
        {
            if (data != null)
            {
                if (data.CustomerCompanyLogoAsByte == null || data.CustomerCompanyLogoAsByte.Length == 0)
                {
                    var pathToDefaultCompanyLogo = Path.Combine(startPathToDefaultData, "retro-wave-logo.png");
                    var defaultCompanyLogoAsByte = ImageDataConverter.PathToImageToByte(pathToDefaultCompanyLogo);
                    data.CustomerCompanyLogoAsByte = defaultCompanyLogoAsByte;
                }

                await _projectRepository.AddProjectAsync(data);
            }
        }

        // Для api репозитория - сохранение ещё не происходит, можно пропустить. Web.Api затем повторно проверит и добавит картинку.
        public async Task AddProjectToDbAsync(ProjectDataModel? data)
        {
            if (data != null)
            {
                await _projectRepository.AddProjectAsync(data);
            }
        }

        public async Task EditProjectToDbAsync(ProjectDataModel? data)
        {
            if (data != null)
            {
                await _projectRepository.UpdateProjectAsync(data);
            }
        }

        public async Task RemoveProjectToDbAsync(int id)
        {
            if (id > 0)
            {
                await _projectRepository.DeleteProjectAsync(id);
            }
        }

        public async Task RemoveProjectToDbAsync(ProjectDataModel? data)
        {
            if (data != null)
            {
                await _projectRepository.DeleteProjectAsync(data.Id);
            }
        }
    }
}
