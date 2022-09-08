using DataModels;

namespace ServiceInterfaces
{
    public interface IServiceService
    {
        public Task<List<ServiceDataModel>> GetAllServiceDatasAsync();
        public Task<List<ServiceDataModel>> GetPublishedServiceDatasAsync();
        public Task<ServiceDataModel?> GetServiceDataByIdAsync(int serviceId);
        public Task AddServiceToDbAsync(ServiceDataModel data);
        public Task EditServiceToDbAsync(ServiceDataModel data);
        public Task RemoveServiceToDbAsync(int id);
    }
}
