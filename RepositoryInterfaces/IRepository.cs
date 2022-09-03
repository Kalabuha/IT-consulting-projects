using Entities.Base;

namespace RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity?> GetEntityAsync(int? id);
        public Task<bool> AddEntityAsync(TEntity entity);
        public Task<bool> UpdateEntityAsync(TEntity entity);
        public Task<bool> RemoveEntityAsync(int id);
    }
}
