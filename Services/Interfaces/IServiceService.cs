using Resources.Models;
using Resources.Datas;

namespace Services.Interfaces
{
    public interface IServiceService
    {
        public Task<List<ServiceData>> GetAllServiceModelsAsync();
        public Task<List<ServiceData>> GetPublishedServiceModelsAsync();
        public Task<ServiceData?> GetServiceDataByIdAsync(int serviceId);
        public Task AddServiceToDbAsync(ServiceData data);
        public Task EditServiceToDbAsync(ServiceData data);
        public Task RemoveServiceToDbAsync(int id);
    }
}
