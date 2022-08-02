using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IContactRepository : IRepository<ContactEntity>
    {
        public Task<ContactEntity[]> GetAllContactEntitiesAsync();
    }
}
