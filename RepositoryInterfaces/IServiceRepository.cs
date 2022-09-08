using DataModels;

namespace RepositoryInterfaces
{
    public interface IServiceRepository
    {
        public Task<ServiceDataModel?> GetServiceAsync(int id);
        public Task<ServiceDataModel[]> GetAllServiceAsync();
        public Task<int> AddServiceAsync(ServiceDataModel data);
        public Task<bool> UpdateServiceAsync(ServiceDataModel data);
        public Task<bool> DeleteServiceAsync(int id);
        
    }
}
