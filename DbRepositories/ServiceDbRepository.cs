using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class ServiceDbRepository : BaseDbRepository<ServiceEntity>, IServiceRepository
    {
        public ServiceDbRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<ServiceEntity[]> GetAllServiceEntitiesAsync()
        {
            var services = await Context.Services
                .ToArrayAsync();

            return services;
        }
    }
}
