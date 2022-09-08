using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class MainPageButtonDbRepository : BaseDbRepository<MainPageButtonEntity>, IMainPageButtonRepository
    {
        public MainPageButtonDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPageButtonDataModel?> GetMainPageButtonAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.MainPageButtonEntityToData();
        }

        public async Task<MainPageButtonDataModel[]> GetAllMainPageButtonsAsync()
        {
            var buttons = await Context.MainPageButtons
                .Select(b => b.MainPageButtonEntityToData())
                .ToArrayAsync();

            return buttons;
        }

        public async Task<int> AddMainPageButtonAsync(MainPageButtonDataModel data)
        {
            var entity = data.MainPageButtonDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateMainPageButtonAsync(MainPageButtonDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.MainPageButtonDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteMainPageButtonAsync(int id)
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
