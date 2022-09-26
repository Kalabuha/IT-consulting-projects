using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class MainPageTextDbRepository : BaseDbRepository<MainPageTextEntity, MainPageTextDataModel>, IRepository<MainPageTextDataModel>
    {
        public MainPageTextDbRepository(DbContextProfiСonnector context)
            : base(context,
                  MainPageElementsEntityAndDataModelMapper.MainPageTextEntityToData,
                  MainPageElementsEntityAndDataModelMapper.MainPageTextDataToEntity)
        { }

        public async Task<MainPageTextDataModel[]> GetAllDataModelsAsync()
        {
            var texts = await Context.MainPageTexts
                .Select(t => MapEntityToData(t))
                .ToArrayAsync();

            return texts;
        }
    }
}