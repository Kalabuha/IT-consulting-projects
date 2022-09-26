using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class ProjectDbRepository : BaseDbRepository<ProjectEntity, ProjectDataModel>, IRepository<ProjectDataModel>
    {
        public ProjectDbRepository(DbContextProfiСonnector context)
            : base(context,
                  ProjectEntityAndDataModelMapper.ProjectEntityToData,
                  ProjectEntityAndDataModelMapper.ProjectDataToEntity)
        { }

        public async Task<ProjectDataModel[]> GetAllDataModelsAsync()
        {
            var projects = await Context.Projects
                .Select(p => MapEntityToData(p))
                .ToArrayAsync();

            return projects;
        }
    }
}
