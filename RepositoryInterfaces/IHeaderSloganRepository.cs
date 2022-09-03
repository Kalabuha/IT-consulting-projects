using Entities;

namespace RepositoryInterfaces
{
    public interface IHeaderSloganRepository : IRepository<SloganEntity>
    {
        public Task<SloganEntity[]> GetAllSloganEntitiesAsync();
        public Task<SloganEntity[]> GetSloganEntitiesAsync();

    }
}
