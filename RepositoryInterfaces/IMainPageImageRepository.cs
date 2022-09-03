using Entities;

namespace RepositoryInterfaces
{
    public interface IMainPageImageRepository : IRepository<MainPageImageEntity>
    {
        public Task<MainPageImageEntity[]> GetAllMainPageImageEntitiesAsync();
    }
}
