﻿using DataModels;

namespace ServiceInterfaces
{
    public interface IProjectService
    {
        public Task<List<ProjectDataModel>> GetAllProjectDatasAsync();
        public Task<List<ProjectDataModel>> GetPublishedProjectDatasAsync();
        public Task<ProjectDataModel?> GetProjectDataByIdAsync(int projectId);
        public Task AddProjectToDbAsync(ProjectDataModel project);
        public Task EditProjectToDbAsync(ProjectDataModel project);
        public Task RemoveProjectToDbAsync(int id);
    }
}
