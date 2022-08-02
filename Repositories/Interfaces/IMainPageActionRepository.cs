using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IMainPageActionRepository : IRepository<MainPageActionEntity>
    {
        public Task<MainPageActionEntity[]> GetAllMainPageActionEntitiesAsync();
    }
}