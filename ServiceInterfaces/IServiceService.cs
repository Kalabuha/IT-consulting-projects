using DataModels;

namespace ServiceInterfaces
{
    public interface IServiceService
    {
        Task<List<ServiceDataModel>> GetAllServiceDatasAsync();
        Task<List<ServiceDataModel>> GetPublishedServiceDatasAsync();
        Task<ServiceDataModel?> GetServiceDataByIdAsync(int serviceId);
        Task AddServiceToDbAsync(ServiceDataModel? data);
        Task<bool> EditServiceToDbAsync(ServiceDataModel? data);
        Task<bool> RemoveServiceToDbAsync(int id);
        Task<bool> RemoveServiceToDbAsync(ServiceDataModel? data);
    }
}
