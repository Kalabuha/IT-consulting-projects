using Entities;

namespace RepositoryInterfaces
{
    public interface IContactRepository : IRepository<ContactEntity>
    {
        public Task<ContactEntity[]> GetAllContactEntitiesAsync();
        public Task<ContactEntity[]> GetAllPublishedContactEntitiesAsync();
    }
}
