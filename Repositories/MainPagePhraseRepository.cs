using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
{
    internal class MainPagePhraseRepository : BaseRepository<MainPagePhraseEntity>, IMainPagePhraseRepository
    {
        public MainPagePhraseRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<MainPagePhraseEntity[]> GetAllMainPagePhraseEntitiesAsync()
        {
            var phrase = await Context.MainPagePhrases
                .ToArrayAsync();

            return phrase;
        }
    }
}
