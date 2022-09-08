using DataModels;

namespace RepositoryInterfaces
{
    public interface IProjectRepository
    {
        public Task<ProjectDataModel?> GetProjectAsync(int id);
        public Task<ProjectDataModel[]> GetAllProjectsAsync();
        public Task<int> AddProjectAsync(ProjectDataModel data);
        public Task<bool> UpdateProjectAsync(ProjectDataModel data);
        public Task<bool> DeleteProjectAsync(int id);
    }
}
