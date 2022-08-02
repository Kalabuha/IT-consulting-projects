using Microsoft.EntityFrameworkCore;
using DbContextProfi;
using Repositories.Base;
using Repositories.Interfaces;
using Resources.Entities;

namespace Repositories
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
