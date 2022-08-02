using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using Repositories.Interfaces;
using Resources.Entities;

namespace Repositories
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
