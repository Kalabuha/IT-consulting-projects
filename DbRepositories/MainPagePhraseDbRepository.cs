using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class MainPagePhraseDbRepository : BaseDbRepository<MainPagePhraseEntity>, IMainPagePhraseRepository
    {
        public MainPagePhraseDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPagePhraseDataModel?> GetMainPagePhraseAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.MainPagePhraseEntityToData();
        }

        public async Task<MainPagePhraseDataModel[]> GetAllMainPagePhrasesAsync()
        {
            var phrase = await Context.MainPagePhrases
                .Select(p => p.MainPagePhraseEntityToData())
                .ToArrayAsync();

            return phrase;
        }

        public async Task<int> AddMainPagePhraseAsync(MainPagePhraseDataModel data)
        {
            var entity = data.MainPagePhraseDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateMainPagePhraseAsync(MainPagePhraseDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.MainPagePhraseDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteMainPagePhraseAsync(int id)
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
