using Entities;

namespace RepositoryInterfaces
{
    public interface IServiceRepository : IRepository<ServiceEntity>
    {
        public Task<ServiceEntity[]> GetAllServiceEntitiesAsync();
    }
}
