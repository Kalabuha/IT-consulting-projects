using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
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