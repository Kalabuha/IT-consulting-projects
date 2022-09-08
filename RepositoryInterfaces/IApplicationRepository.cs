using DataModels;

namespace RepositoryInterfaces
{
    public interface IApplicationRepository
    {
        public Task<ApplicationDataModel?> GetApplicationAsync(int id);
        public Task<ApplicationDataModel[]> GetAllApplicationAsync();
        public Task<int> AddApplicationAsync(ApplicationDataModel data);
        public Task<bool> UpdateApplicationAsync(ApplicationDataModel data);
        public Task<bool> DeleteApplicationAsync(int id);
    }
}
