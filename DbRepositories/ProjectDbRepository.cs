using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class ProjectDbRepository : BaseDbRepository<ProjectEntity>, IProjectRepository
    {
        public ProjectDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<ProjectDataModel?> GetProjectAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.ProjectEntityToData();
        }

        public async Task<ProjectDataModel[]> GetAllProjectsAsync()
        {
            var projects = await Context.Projects
                .Select(p => p.ProjectEntityToData())
                .ToArrayAsync();

            return projects;
        }

        public async Task<int> AddProjectAsync(ProjectDataModel data)
        {
            var entity = data.ProjectDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateProjectAsync(ProjectDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.ProjectDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            if (entity == null)
            {
                return false;
            }

            await RemoveEntityAsync(entity);
            return true;
        }
    }
}
