using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class MainPagePhraseDbRepository : BaseDbRepository<MainPagePhraseEntity, MainPagePhraseDataModel>, IRepository<MainPagePhraseDataModel>
    {
        public MainPagePhraseDbRepository(DbContextProfiСonnector context)
            : base(context, MainPageElementsEntityAndDataModelMapper.MainPagePhraseEntityToData,
                  MainPageElementsEntityAndDataModelMapper.MainPagePhraseDataToEntity)
        { }

        public async Task<MainPagePhraseDataModel[]> GetAllDataModelsAsync()
        {
            var phrase = await Context.MainPagePhrases
                .Select(p => MapEntityToData(p))
                .ToArrayAsync();

            return phrase;
        }
    }
}
