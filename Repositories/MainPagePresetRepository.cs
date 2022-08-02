using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
{
    internal class MainPagePresetRepository : BaseRepository<MainPagePresetEntity>, IMainPagePresetRepository
    {
        public MainPagePresetRepository(DbContextProfiСonnector context) : base(context) {}

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
