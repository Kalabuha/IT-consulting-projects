using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class MainPageButtonRepository : BaseRepository<MainPageButtonEntity>, IMainPageButtonRepository
    {
        public MainPageButtonRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<MainPageButtonEntity[]> GetAllMainPageButtonEntitiesAsync()
        {
            var buttons = await Context.MainPageButtons
                .ToArrayAsync();

            return buttons;
        }
    }
}
