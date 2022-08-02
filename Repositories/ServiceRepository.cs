using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
{
    internal class ServiceRepository : BaseRepository<ServiceEntity>, IServiceRepository
    {
        public ServiceRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<ServiceEntity[]> GetAllServiceEntitiesAsync()
        {
            var services = await Context.Services
                .ToArrayAsync();

            return services;
        }
    }
}
