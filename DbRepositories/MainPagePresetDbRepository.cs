using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPagePresetDbRepository : BaseDbRepository<MainPagePresetEntity>, IMainPagePresetRepository
    {
        public MainPagePresetDbRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<MainPagePresetEntity[]> GetAllMainPagePresetEntitiesAsync()
        {
            var presets = await Context.MainPagePresets
                .ToArrayAsync();

            return presets;
        }

        public async Task<MainPagePresetEntity[]> GetAllPublishedPresetEntityAsync()
        {
            var presets = await Context.MainPagePresets
                .Where(p => p.IsPublishedOnMainPage == true)
                .ToArrayAsync();

            return presets;
        }

        public async Task<MainPagePresetEntity?> GetPublishedMainPagePresetEntityAsync()
        {
            var publishedPreset = await Context.MainPagePresets
                .FirstOrDefaultAsync(p => p.IsPublishedOnMainPage);

            return publishedPreset;
        }
    }
}
