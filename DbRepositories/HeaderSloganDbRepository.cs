using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using DbRepositories.Base;
using RepositoryInterfaces;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class HeaderSloganDbRepository : BaseDbRepository<HeaderSloganEntity>, IHeaderSloganRepository
    {
        public HeaderSloganDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<HeaderSloganDataModel?> GetHeaderSloganAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.HeaderSloganEntityToData();
        }

        public async Task<HeaderSloganDataModel[]> GetAllHeaderSlogansAsync()
        {
            var slogans = await Context.HeaderSlogans
                .Select(h => h.HeaderSloganEntityToData())
                .ToArrayAsync();

            return slogans;
        }

        public async Task<int> AddHeaderSloganAsync(HeaderSloganDataModel data)
        {
            var entity = data.HeaderSloganDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateHeaderSloganAsync(HeaderSloganDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.HeaderSloganDataToEntity();
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteHeaderSloganAsync(int id)
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
