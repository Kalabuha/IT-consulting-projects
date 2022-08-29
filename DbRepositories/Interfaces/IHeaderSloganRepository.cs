using Entities;

namespace DbRepositories.Interfaces
{
    public interface IHeaderSloganRepository : IRepository<SloganEntity>
    {
        public Task<SloganEntity[]> GetAllSloganEntitiesAsync();
        public Task<SloganEntity[]> GetSloganEntitiesAsync();

    }
}
