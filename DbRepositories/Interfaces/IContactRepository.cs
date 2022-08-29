using Entities;

namespace DbRepositories.Interfaces
{
    public interface IContactRepository : IRepository<ContactEntity>
    {
        public Task<ContactEntity[]> GetAllContactEntitiesAsync();
        public Task<ContactEntity[]> GetAllPublishedContactEntitiesAsync();
    }
}
