using Resources.Models;
using Resources.Datas;

namespace Services.Interfaces
{
    public interface IProjectService
    {
        public Task<List<ProjectData>> GetAllProjectDatasAsync();
        public Task<List<ProjectData>> GetPublishedProjectDatasAsync();
        public Task<ProjectData?> GetProjectDataByIdAsync(int projectId);
        public Task AddProjectToDbAsync(ProjectData project);
        public Task EditProjectToDbAsync(ProjectData project);
        public Task RemoveProjectToDbAsync(int id);

    }
}
