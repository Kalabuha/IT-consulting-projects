using System.Net.Http.Json;
using Resources.Datas;
using Services.Interfaces;

namespace Services.Api
{
    internal class ProjectApiService : IProjectService
    {


        public ProjectApiService()
        {

        }

        public Task<List<ProjectData>> GetAllProjectDatasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectData?> GetProjectDataByIdAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProjectData>> GetPublishedProjectDatasAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddProjectToDbAsync(ProjectData project)
        {
            throw new NotImplementedException();
        }

        public Task EditProjectToDbAsync(ProjectData project)
        {
            throw new NotImplementedException();
        }

        public Task RemoveProjectToDbAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
