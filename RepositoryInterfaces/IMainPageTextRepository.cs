using Entities;

namespace RepositoryInterfaces
{
    public interface IMainPageTextRepository : IRepository<MainPageTextEntity>
    {
        public Task<MainPageTextEntity[]> GetAllMainPageTextEntitiesAsync();
    }
}
