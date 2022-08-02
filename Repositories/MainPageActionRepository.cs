using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
{
    internal class MainPageActionRepository : BaseRepository<MainPageActionEntity>, IMainPageActionRepository
    {
        public MainPageActionRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<MainPageActionEntity[]> GetAllMainPageActionEntitiesAsync()
        {
            var actions = await Context.MainPageActions
                .ToArrayAsync();

            return actions;
        }
    }
}
