using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
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
