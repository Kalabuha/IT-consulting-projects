using Microsoft.EntityFrameworkCore;
using DbRepositories.Interfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPageTextRepository : BaseRepository<MainPageTextEntity>, IMainPageTextRepository
    {
        public MainPageTextRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPageTextEntity[]> GetAllMainPageTextEntitiesAsync()
        {
            var texts = await Context.MainPageTexts
                .ToArrayAsync();

            return texts;
        }
    }
}