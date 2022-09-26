using DataModels;

namespace ServiceInterfaces
{
    public interface IProjectService
    {
        Task<List<ProjectDataModel>> GetAllProjectDatasAsync();
        Task<List<ProjectDataModel>> GetPublishedProjectDatasAsync();
        Task<ProjectDataModel?> GetProjectDataByIdAsync(int id);

        // Для Db репозитория.
        Task AddProjectToDbAndAddDefaultImageAsync(ProjectDataModel? project, string startPathToDefaultData);

        // Для Api репозитория.
        Task AddProjectToDbAsync(ProjectDataModel? project);
        Task<bool> EditProjectToDbAsync(ProjectDataModel? project);
        Task<bool> RemoveProjectToDbAsync(int id);
        Task<bool> RemoveProjectToDbAsync(ProjectDataModel? data);
    }
}
