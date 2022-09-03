using Entities;

namespace RepositoryInterfaces
{
    public interface IHeaderMenuSetRepository : IRepository<MenuEntity>
    {
        public Task<MenuEntity[]> GetAllMenuEntitiesAsync();
        public Task<MenuEntity?> GetUsedMenuEntityAsync();

    }
}
