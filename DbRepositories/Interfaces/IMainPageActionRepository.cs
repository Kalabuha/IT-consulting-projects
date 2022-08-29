using Entities;

namespace DbRepositories.Interfaces
{
    public interface IMainPageActionRepository : IRepository<MainPageActionEntity>
    {
        public Task<MainPageActionEntity[]> GetAllMainPageActionEntitiesAsync();
    }
}