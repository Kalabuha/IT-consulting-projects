using Microsoft.EntityFrameworkCore;
using DbRepositories.Interfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
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
