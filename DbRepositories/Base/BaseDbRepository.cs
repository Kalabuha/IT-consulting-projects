using DbContextProfi;
using Entities.Base;
using DataModels.Base;
using RepositoryInterfaces;
using MapperDelegates;

namespace DbRepositories.Base
{
    public abstract class BaseDbRepository<TEntity, TData> : IBaseRepository<TData>
        where TEntity : BaseEntity
        where TData : BaseDataModel
    {
        protected DbContextProfiСonnector Context { get; }

        protected Func<TEntity, TData> MapEntityToData;
        protected DataToEntityFunc<TData, TEntity, TEntity> MapDataToEntity;

        public BaseDbRepository(
            DbContextProfiСonnector context,
            Func<TEntity, TData> mapEntityToData,
            DataToEntityFunc<TData, TEntity, TEntity> mapDataToEntity)
        {
            Context = context;

            MapEntityToData = mapEntityToData;
            MapDataToEntity = mapDataToEntity;
        }

        public async Task<TData?> GetDataModelAsync(int id)
        {
            var entity = await Context.FindAsync<TEntity>(id);
            if (entity == null)
            {
                return null;
            }

            return MapEntityToData(entity);
        }

        public async Task<TData> AddDataModelAsync(TData data)
        {
            var entity = MapDataToEntity(data);
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return MapEntityToData(entity);
        }

        public async Task<bool> UpdateDataModelAsync(TData data)
        {
            var entity = await Context.FindAsync<TEntity>(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = MapDataToEntity(data, entity);
            Context.Update(updated);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteDataModelAsync(int id)
        {
            var entity = await Context.FindAsync<TEntity>(id);
            if (entity == null)
            {
                return false;
            }

            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
