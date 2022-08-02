using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        public Task AddEntityAsync(ApplicationEntity entity);
        public Task UpdateEntityAsync(ApplicationEntity entity);
        public Task RemoveEntityAsync(ApplicationEntity entity);
        public Task<ApplicationEntity?> GetEntity(int? id);
        public Task<ApplicationEntity[]> GetApplicationsAsync();
    }
}
