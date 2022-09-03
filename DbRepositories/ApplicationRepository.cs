using Microsoft.EntityFrameworkCore;
using DbContextProfi;
using DbRepositories.Base;
using RepositoryInterfaces;
using Entities;

namespace DbRepositories
{
    internal class ApplicationRepository : BaseRepository<ApplicationEntity>, IApplicationRepository
    {
        public ApplicationRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<ApplicationEntity[]> GetApplicationsAsync()
        {
            var applications = await Context.Applications
                .ToArrayAsync();

            return applications;
        }
    }
}
