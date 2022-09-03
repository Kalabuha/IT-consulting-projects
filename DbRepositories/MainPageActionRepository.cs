using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
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
