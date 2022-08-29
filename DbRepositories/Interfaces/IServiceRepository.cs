using Entities;

namespace DbRepositories.Interfaces
{
    public interface IServiceRepository : IRepository<ServiceEntity>
    {
        public Task<ServiceEntity[]> GetAllServiceEntitiesAsync();
    }
}
