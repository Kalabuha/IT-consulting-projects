using Entities;

namespace DbRepositories.Interfaces
{
    public interface IMainPageImageRepository : IRepository<MainPageImageEntity>
    {
        public Task<MainPageImageEntity[]> GetAllMainPageImageEntitiesAsync();
    }
}
