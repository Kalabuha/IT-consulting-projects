using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IProjectRepository : IRepository<ProjectEntity>
    {
        public Task<ProjectEntity[]> GetAllProjectEntitiesAsync();
    }
}
