using DbContextProfi;
using Microsoft.EntityFrameworkCore;
using DbRepositories.Base;
using RepositoryInterfaces;
using Entities;

namespace DbRepositories
{
    internal class HeaderMenuSetRepository : BaseRepository<MenuEntity>, IHeaderMenuSetRepository
    {
        public HeaderMenuSetRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<MenuEntity[]> GetAllMenuEntitiesAsync()
        {
            var headerMenuSets = await Context.HeaderMenuSets
                .ToArrayAsync();

            return headerMenuSets;
        }

        public async Task<MenuEntity?> GetUsedMenuEntityAsync()
        {
            var usedHeaderMenuSets = await Context.HeaderMenuSets
                .FirstOrDefaultAsync(m => m.IsPublishedOnMainPage == true);

            return usedHeaderMenuSets;
        }
    }
}
