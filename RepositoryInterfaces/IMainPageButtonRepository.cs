using Entities;

namespace RepositoryInterfaces
{
    public interface IMainPageButtonRepository : IRepository<MainPageButtonEntity>
    {
        public Task<MainPageButtonEntity[]> GetAllMainPageButtonEntitiesAsync();

    }
}
