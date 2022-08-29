using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using DbRepositories.Base;
using DbRepositories.Interfaces;
using Entities;

namespace DbRepositories
{
    internal class HeaderSloganRepository : BaseRepository<SloganEntity>, IHeaderSloganRepository
    {
        public HeaderSloganRepository(DbContextProfiСonnector context) : base(context) {}

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
