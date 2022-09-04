using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPageActionDbRepository : BaseDbRepository<MainPageActionEntity>, IMainPageActionRepository
    {
        public MainPageActionDbRepository(DbContextProfiСonnector context) : base(context) {}

        public async Task<MainPageActionEntity[]> GetAllMainPageActionEntitiesAsync()
        {
            var actions = await Context.MainPageActions
                .ToArrayAsync();

            return actions;
        }
    }
}
