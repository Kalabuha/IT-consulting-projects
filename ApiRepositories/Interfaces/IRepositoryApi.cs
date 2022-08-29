using Entities.Base;

namespace ApiRepositories.Interfaces
{
    public interface IRepositoryApi<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity?> GetResource(int id);
        public Task<bool> AddResourceAsync(TEntity entity);
        public Task<bool> UpdateResourceAsync(TEntity entity);
        public Task<bool> DeleteResourceAsync(int id);
    }
}
