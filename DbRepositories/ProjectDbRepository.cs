using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class ProjectDbRepository : BaseDbRepository<ProjectEntity>, IProjectRepository
    {
        public ProjectDbRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<ProjectEntity[]> GetAllProjectEntitiesAsync()
        {
            var projects = await Context.Projects
                .ToArrayAsync();

            return projects;
        }
    }
}
