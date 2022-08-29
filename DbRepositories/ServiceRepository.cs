using Microsoft.EntityFrameworkCore;
using DbRepositories.Interfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
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
