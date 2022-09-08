using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using DbRepositories.Base;
using RepositoryInterfaces;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class HeaderMenuDbRepository : BaseDbRepository<HeaderMenuEntity>, IHeaderMenuRepository
    {
        public HeaderMenuDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<HeaderMenuDataModel?> GetHeaderMenuAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.HeaderMenuEntityToData();
        }

        public async Task<HeaderMenuDataModel[]> GetAllHeaderMenusAsync()
        {
            var headerMenuSets = await Context.HeaderMenus
                .Select(m => m.HeaderMenuEntityToData())
                .ToArrayAsync();

            return headerMenuSets;
        }

        public async Task<int> AddHeaderMenuAsync(HeaderMenuDataModel data)
        {
            var entity = data.HeaderMenuDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateHeaderMenuAsync(HeaderMenuDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.HeaderMenuDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteHeaderMenuAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            if (entity == null)
            {
                return false;
            }

            await RemoveEntityAsync(entity);
            return true;
        }
    }
}
