using Entities;

namespace RepositoryInterfaces
{
    public interface IMainPageActionRepository : IRepository<MainPageActionEntity>
    {
        public Task<MainPageActionEntity[]> GetAllMainPageActionEntitiesAsync();
    }
}