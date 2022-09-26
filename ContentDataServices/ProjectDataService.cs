using RepositoryInterfaces;
using ServiceInterfaces;
using DefaultDataServices;
using CommonDataConverters;
using DataModels;

namespace ContentDataServices
{
    internal class ProjectDataService : DefaultDataService, IProjectService
    {
        private readonly IRepository<ProjectDataModel> _projectRepository;

        public ProjectDataService(IRepository<ProjectDataModel> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<ProjectDataModel>> GetAllProjectDatasAsync()
        {
            var datas = (await _projectRepository.GetAllDataModelsAsync())
                .ToList();

            return datas;
        }

        public async Task<List<ProjectDataModel>> GetPublishedProjectDatasAsync()
        {
            var projects = (await _projectRepository.GetAllDataModelsAsync())
                .Where(p => p.IsPublished)
                .ToList();

            return projects;
        }

        public async Task<ProjectDataModel?> GetProjectDataByIdAsync(int id)
        {
            var project = await _projectRepository.GetDataModelAsync(id);

            return project;
        }

        // Для Db репозитория - перед сохранением необходимо убедится, что есть картинка и добавить её если она отстутствует.
        public async Task AddProjectToDbAndAddDefaultImageAsync(ProjectDataModel? data, string startPathToDefaultData)
        {
            if (data != null)
            {
                if (data.CustomerCompanyLogoAsByte == null || data.CustomerCompanyLogoAsByte.Length == 0)
                {
                    var pathToDefaultCompanyLogo = Path.Combine(startPathToDefaultData, "retro-wave-logo.png");
                    var defaultCompanyLogoAsByte = ImageDataConverter.PathToImageToByte(pathToDefaultCompanyLogo);
                    data.CustomerCompanyLogoAsByte = defaultCompanyLogoAsByte;
                }

                await _projectRepository.AddDataModelAsync(data);
            }
        }

        // Для api репозитория - сохранение ещё не происходит, можно пропустить. Web.Api затем повторно проверит и добавит картинку.
        public async Task AddProjectToDbAsync(ProjectDataModel? data)
        {
            if (data != null)
            {
                await _projectRepository.AddDataModelAsync(data);
            }
        }

        public async Task<bool> EditProjectToDbAsync(ProjectDataModel? data)
        {
            if (data != null)
            {
                return await _projectRepository.UpdateDataModelAsync(data);
            }

            return false;
        }

        public async Task<bool> RemoveProjectToDbAsync(int id)
        {
            if (id > 0)
            {
                return await _projectRepository.DeleteDataModelAsync(id);
            }

            return false;
        }

        public async Task<bool> RemoveProjectToDbAsync(ProjectDataModel? data)
        {
            return await RemoveProjectToDbAsync(data != null ? data.Id : 0);
        }
    }
}
