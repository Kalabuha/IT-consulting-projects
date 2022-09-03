using Entities;

namespace RepositoryInterfaces
{
    public interface IProjectRepository : IRepository<ProjectEntity>
    {
        public Task<ProjectEntity[]> GetAllProjectEntitiesAsync();
    }
}
