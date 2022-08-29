using Entities;

namespace DbRepositories.Interfaces
{
    public interface IProjectRepository : IRepository<ProjectEntity>
    {
        public Task<ProjectEntity[]> GetAllProjectEntitiesAsync();
    }
}
