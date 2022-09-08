using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class MainPageActionDbRepository : BaseDbRepository<MainPageActionEntity>, IMainPageActionRepository
    {
        public MainPageActionDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPageActionDataModel?> GetMainPageActionAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.MainPageActionEntityToData();
        }

        public async Task<MainPageActionDataModel[]> GetAllMainPageActionsAsync()
        {
            var actions = await Context.MainPageActions
                .Select(a => a.MainPageActionEntityToData())
                .ToArrayAsync();

            return actions;
        }

        public async Task<int> AddMainPageActionAsync(MainPageActionDataModel data)
        {
            var entity = data.MainPageActionDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateMainPageActionAsync(MainPageActionDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.MainPageActionDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteMainPageActionAsync(int id)
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
