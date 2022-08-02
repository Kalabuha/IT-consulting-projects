using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IMainPageButtonRepository : IRepository<MainPageButtonEntity>
    {
        public Task<MainPageButtonEntity[]> GetAllMainPageButtonEntitiesAsync();

    }
}
