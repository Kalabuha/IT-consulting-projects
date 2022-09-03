using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class ProjectRepository : BaseRepository<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<ProjectEntity[]> GetAllProjectEntitiesAsync()
        {
            var projects = await Context.Projects
                .ToArrayAsync();

            return projects;
        }
    }
}
