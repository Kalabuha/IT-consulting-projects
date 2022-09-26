using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class MainPageImageDbRepository : BaseDbRepository<MainPageImageEntity, MainPageImageDataModel>, IRepository<MainPageImageDataModel>
    {
        public MainPageImageDbRepository(DbContextProfiСonnector context)
            : base(context,
                  MainPageElementsEntityAndDataModelMapper.MainPageImageEntityToData,
                  MainPageElementsEntityAndDataModelMapper.MainPageImageDataToEntity)
        { }

        public async Task<MainPageImageDataModel[]> GetAllDataModelsAsync()
        {
            var images = await Context.MainPageImages
                .Select(i => MapEntityToData(i))
                .ToArrayAsync();

            return images;
        }
    }
}
