using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPageTextDbRepository : BaseDbRepository<MainPageTextEntity>, IMainPageTextRepository
    {
        public MainPageTextDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPageTextEntity[]> GetAllMainPageTextEntitiesAsync()
        {
            var texts = await Context.MainPageTexts
                .ToArrayAsync();

            return texts;
        }
    }
}