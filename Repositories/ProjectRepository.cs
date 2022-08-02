using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
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
