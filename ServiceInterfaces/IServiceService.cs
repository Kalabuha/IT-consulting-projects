using DataModels;

namespace ServiceInterfaces
{
    public interface IServiceService
    {
        public Task<List<ServiceData>> GetAllServiceDatasAsync();
        public Task<List<ServiceData>> GetPublishedServiceDatasAsync();
        public Task<ServiceData?> GetServiceDataByIdAsync(int serviceId);
        public Task AddServiceToDbAsync(ServiceData data);
        public Task EditServiceToDbAsync(ServiceData data);
        public Task RemoveServiceToDbAsync(int id);
    }
}
