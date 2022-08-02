using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IServiceRepository : IRepository<ServiceEntity>
    {
        public Task<ServiceEntity[]> GetAllServiceEntitiesAsync();
    }
}
