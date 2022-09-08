using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using DataModels;
using EntitiesDataModelsMappers;
using Entities;

namespace DbRepositories
{
    internal class MainPageImageDbRepository : BaseDbRepository<MainPageImageEntity>, IMainPageImageRepository
    {
        public MainPageImageDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPageImageDataModel?> GetMainPageImageAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.MainPageImageEntityToData();
        }

        public async Task<MainPageImageDataModel[]> GetAllMainPageImagesAsync()
        {
            var images = await Context.MainPageImages
                .Select(i => i.MainPageImageEntityToData())
                .ToArrayAsync();

            return images;
        }

        public async Task<int> AddMainPageImageAsync(MainPageImageDataModel data)
        {
            var entity = data.MainPageImageDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateMainPageImageAsync(MainPageImageDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.MainPageImageDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteMainPageImageAsync(int id)
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
