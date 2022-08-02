using DbContextProfi;
using Repositories.Interfaces;
using Resources.Entities.Base;

namespace Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContextProfiСonnector Context { get; }

        public BaseRepository(DbContextProfiСonnector context)
        {
            Context = context;
        }

        public async Task AddEntityAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateEntityAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveEntityAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<TEntity?> GetEntity(int? id)
        {
            return id.HasValue ? await Context.FindAsync<TEntity>(id) : null;
        }
    }
}
