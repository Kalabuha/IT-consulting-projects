using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using DbRepositories.Base;
using RepositoryInterfaces;
using Entities;

namespace DbRepositories
{
    internal class HeaderSloganDbRepository : BaseDbRepository<SloganEntity>, IHeaderSloganRepository
    {
        public HeaderSloganDbRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<SloganEntity[]> GetAllSloganEntitiesAsync()
        {
            var slogans = await Context.HeaderSlogans
                .ToArrayAsync();

            return slogans;
        }

        public async Task<SloganEntity[]> GetSloganEntitiesAsync()
        {
            var usedSlogans = await Context.HeaderSlogans
                .Where(s => s.IsUsed == true)
                .ToArrayAsync();

            return usedSlogans;
        }
    }
}
