using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
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
