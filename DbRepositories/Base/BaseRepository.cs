using DbContextProfi;
using RepositoryInterfaces;
using Entities.Base;

namespace DbRepositories.Base
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContextProfiСonnector Context { get; }

        public BaseRepository(DbContextProfiСonnector context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetEntityAsync(int? id)
        {
            return id.HasValue ? await Context.FindAsync<TEntity>(id) : null;
        }

        public async Task<bool> AddEntityAsync(TEntity entity)
        {
            if (entity != null)
            {
                await Context.AddAsync(entity);
                await Context.SaveChangesAsync();
                return true;
            }
            
            return false;
        }

        public async Task<bool> UpdateEntityAsync(TEntity entity)
        {
            var entityFromDb = await GetEntityAsync(entity.Id);
            if (entityFromDb != null)
            {
                Context.Update(entity);
                await Context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveEntityAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            if (entity != null)
            {
                Context.Remove(entity);
                await Context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
