using Resources.Entities.Base;

namespace Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public Task AddEntityAsync(TEntity entity);

        public Task UpdateEntityAsync(TEntity entity);

        public Task RemoveEntityAsync(TEntity entity);

        public Task<TEntity?> GetEntity(int? id);
    }
}
