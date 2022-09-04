using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPageButtonDbRepository : BaseDbRepository<MainPageButtonEntity>, IMainPageButtonRepository
    {
        public MainPageButtonDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPageButtonEntity[]> GetAllMainPageButtonEntitiesAsync()
        {
            var buttons = await Context.MainPageButtons
                .ToArrayAsync();

            return buttons;
        }
    }
}
