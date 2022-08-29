using Entities;

namespace DbRepositories.Interfaces
{
    public interface IMainPageTextRepository : IRepository<MainPageTextEntity>
    {
        public Task<MainPageTextEntity[]> GetAllMainPageTextEntitiesAsync();
    }
}
