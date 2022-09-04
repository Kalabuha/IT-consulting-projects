using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPagePhraseDbRepository : BaseDbRepository<MainPagePhraseEntity>, IMainPagePhraseRepository
    {
        public MainPagePhraseDbRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<MainPagePhraseEntity[]> GetAllMainPagePhraseEntitiesAsync()
        {
            var phrase = await Context.MainPagePhrases
                .ToArrayAsync();

            return phrase;
        }
    }
}
