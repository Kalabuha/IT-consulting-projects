using Entities;

namespace DbRepositories.Interfaces
{
    public interface IHeaderMenuSetRepository : IRepository<MenuEntity>
    {
        public Task<MenuEntity[]> GetAllMenuEntitiesAsync();
        public Task<MenuEntity?> GetUsedMenuEntityAsync();

    }
}
