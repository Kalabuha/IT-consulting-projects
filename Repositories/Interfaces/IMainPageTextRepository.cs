using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IMainPageTextRepository : IRepository<MainPageTextEntity>
    {
        public Task<MainPageTextEntity[]> GetAllMainPageTextEntitiesAsync();
    }
}
