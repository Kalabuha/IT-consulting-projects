using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IHeaderMenuSetRepository : IRepository<MenuEntity>
    {
        public Task<MenuEntity[]> GetAllMenuEntitiesAsync();
        public Task<MenuEntity?> GetUsedMenuEntityAsync();

    }
}
