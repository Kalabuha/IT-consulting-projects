using Entities;

namespace RepositoryInterfaces
{
    public interface IApplicationRepository : IRepository<ApplicationEntity>
    {
        public Task<ApplicationEntity[]> GetApplicationsAsync();
    }
}
