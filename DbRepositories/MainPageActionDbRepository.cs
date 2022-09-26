using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class MainPageActionDbRepository : BaseDbRepository<MainPageActionEntity, MainPageActionDataModel>, IRepository<MainPageActionDataModel>
    {
        public MainPageActionDbRepository(DbContextProfiСonnector context)
            : base(context,
                  MainPageElementsEntityAndDataModelMapper.MainPageActionEntityToData,
                  MainPageElementsEntityAndDataModelMapper.MainPageActionDataToEntity)
        { }

        public async Task<MainPageActionDataModel[]> GetAllDataModelsAsync()
        {
            var actions = await Context.MainPageActions
                .Select(a => MapEntityToData(a))
                .ToArrayAsync();

            return actions;
        }
    }
}
