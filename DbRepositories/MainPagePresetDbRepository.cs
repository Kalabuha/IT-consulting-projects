using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class MainPagePresetDbRepository : BaseDbRepository<MainPagePresetEntity, MainPagePresetDataModel>, IRepository<MainPagePresetDataModel>
    {
        public MainPagePresetDbRepository(DbContextProfiСonnector context)
            : base(context,
                  MainPageElementsEntityAndDataModelMapper.MainPagePresetEntityToData,
                  MainPageElementsEntityAndDataModelMapper.MainPagePresetDataToEntity)
        { }

        public async Task<MainPagePresetDataModel[]> GetAllDataModelsAsync()
        {
            var presets = await Context.MainPagePresets
                .Select(p => MapEntityToData(p))
                .ToArrayAsync();

            return presets;
        }
    }
}
