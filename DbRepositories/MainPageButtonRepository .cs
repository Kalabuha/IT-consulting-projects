using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class MainPageButtonDbRepository : BaseDbRepository<MainPageButtonEntity, MainPageButtonDataModel>, IRepository<MainPageButtonDataModel>
    {
        public MainPageButtonDbRepository(DbContextProfiСonnector context)
            : base(context,
                  MainPageElementsEntityAndDataModelMapper.MainPageButtonEntityToData,
                  MainPageElementsEntityAndDataModelMapper.MainPageButtonDataToEntity)
        { }

        public async Task<MainPageButtonDataModel[]> GetAllDataModelsAsync()
        {
            var buttons = await Context.MainPageButtons
                .Select(b => MapEntityToData(b))
                .ToArrayAsync();

            return buttons;
        }
    }
}
