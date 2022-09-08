using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class MainPagePresetDbRepository : BaseDbRepository<MainPagePresetEntity>, IMainPagePresetRepository
    {
        public MainPagePresetDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPagePresetDataModel?> GetMainPagePresetAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.MainPagePresetEntityToData();
        }

        public async Task<MainPagePresetDataModel[]> GetAllMainPagePresetsAsync()
        {
            var presets = await Context.MainPagePresets
                .Select(p => p.MainPagePresetEntityToData())
                .ToArrayAsync();

            return presets;
        }

        public async Task<int> AddMainPagePresetAsync(MainPagePresetDataModel data)
        {
            var entity = data.MainPagePresetDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateMainPagePresetAsync(MainPagePresetDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.MainPagePresetDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteMainPagePresetAsync(int id)
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
