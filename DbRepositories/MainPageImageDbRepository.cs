using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPageImageDbRepository : BaseDbRepository<MainPageImageEntity>, IMainPageImageRepository
    {
        public MainPageImageDbRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<MainPageImageEntity[]> GetAllMainPageImageEntitiesAsync()
        {
            var images = await Context.MainPageImages
                .ToArrayAsync();

            return images;
        }
    }
}
