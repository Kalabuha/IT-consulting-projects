using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class MainPageTextDbRepository : BaseDbRepository<MainPageTextEntity>, IMainPageTextRepository
    {
        public MainPageTextDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPageTextDataModel?> GetMainPageTextAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.MainPageTextEntityToData();
        }

        public async Task<MainPageTextDataModel[]> GetAllMainPageTextsAsync()
        {
            var texts = await Context.MainPageTexts
                .Select(t => t.MainPageTextEntityToData())
                .ToArrayAsync();

            return texts;
        }

        public async Task<int> AddMainPageTextAsync(MainPageTextDataModel data)
        {
            var entity = data.MainPageTextDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateMainPageTextAsync(MainPageTextDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.MainPageTextDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteMainPageTextAsync(int id)
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