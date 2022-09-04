using Microsoft.EntityFrameworkCore;
using DbContextProfi;
using DbRepositories.Base;
using RepositoryInterfaces;
using Entities;

namespace DbRepositories
{
    internal class ApplicationDbRepository : BaseDbRepository<ApplicationEntity>, IApplicationRepository
    {
        public ApplicationDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<ApplicationEntity[]> GetAllApplicationEntitiesAsync()
        {
            var applications = await Context.Applications
                .ToArrayAsync();

            return applications;
        }
    }
}
