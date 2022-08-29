using Entities;

namespace DbRepositories.Interfaces
{
    public interface IMainPageButtonRepository : IRepository<MainPageButtonEntity>
    {
        public Task<MainPageButtonEntity[]> GetAllMainPageButtonEntitiesAsync();

    }
}
