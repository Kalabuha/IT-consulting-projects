using RepositoryInterfaces;
using ServiceInterfaces;
using DataModels;

namespace ContentDataServices
{
    internal class ServiceDataService : IServiceService
    {
        private readonly IRepository<ServiceDataModel> _serviceRepository;

        public ServiceDataService(IRepository<ServiceDataModel> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<ServiceDataModel>> GetAllServiceDatasAsync()
        {
            var services = (await _serviceRepository.GetAllDataModelsAsync())
                .ToList();

            return services;
        }

        public async Task<List<ServiceDataModel>> GetPublishedServiceDatasAsync()
        {
            var services = (await _serviceRepository.GetAllDataModelsAsync())
                .Where(s => s.IsPublished)
                .ToList();

            return services;
        }

        public async Task<ServiceDataModel?> GetServiceDataByIdAsync(int id)
        {
            var service = await _serviceRepository.GetDataModelAsync(id);

            return service;
        }

        public async Task AddServiceToDbAsync(ServiceDataModel? data)
        {
            if (data != null)
            {
                await _serviceRepository.AddDataModelAsync(data);
            }
        }

        public async Task<bool> EditServiceToDbAsync(ServiceDataModel? data)
        {
            if (data != null)
            {
                return await _serviceRepository.UpdateDataModelAsync(data);
            }

            return false;
        }

        public async Task<bool> RemoveServiceToDbAsync(int id)
        {
            if (id > 0)
            {
                return await _serviceRepository.DeleteDataModelAsync(id);
            }

            return false;
        }

        public async Task<bool> RemoveServiceToDbAsync(ServiceDataModel? data)
        {
            return await RemoveServiceToDbAsync(data != null ? data.Id : 0);
        }
    }
}
