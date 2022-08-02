using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IMainPageImageRepository : IRepository<MainPageImageEntity>
    {
        public Task<MainPageImageEntity[]> GetAllMainPageImageEntitiesAsync();
    }
}
