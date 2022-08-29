using Microsoft.EntityFrameworkCore;
using DbRepositories.Interfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPageImageRepository : BaseRepository<MainPageImageEntity>, IMainPageImageRepository
    {
        public MainPageImageRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<MainPageImageEntity[]> GetAllMainPageImageEntitiesAsync()
        {
            var images = await Context.MainPageImages
                .ToArrayAsync();

            return images;
        }
    }
}
