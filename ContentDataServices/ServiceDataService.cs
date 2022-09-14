using RepositoryInterfaces;
using ServiceInterfaces;
using DataModels;

namespace ContentDataServices
{
    internal class ServiceDataService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceDataService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<ServiceDataModel>> GetAllServiceDatasAsync()
        {
            var services = (await _serviceRepository.GetAllServiceAsync())
                .ToList();

            return services;
        }

        public async Task<List<ServiceDataModel>> GetPublishedServiceDatasAsync()
        {
            var services = (await _serviceRepository.GetAllServiceAsync())
                .Where(s => s.IsPublished)
                .ToList();

            return services;
        }

        public async Task<ServiceDataModel?> GetServiceDataByIdAsync(int id)
        {
            var service = await _serviceRepository.GetServiceAsync(id);

            return service;
        }

        public async Task AddServiceToDbAsync(ServiceDataModel? data)
        {
            if (data != null)
            {
                await _serviceRepository.AddServiceAsync(data);
            }
        }

        public async Task EditServiceToDbAsync(ServiceDataModel? data)
        {
            if (data != null)
            {
                await _serviceRepository.UpdateServiceAsync(data);
            }
        }

        public async Task RemoveServiceToDbAsync(int id)
        {
            if (id > 0)
            {
                await _serviceRepository.DeleteServiceAsync(id);
            }
        }

        public async Task RemoveServiceToDbAsync(ServiceDataModel? data)
        {
            if (data != null)
            {
                await _serviceRepository.DeleteServiceAsync(data.Id);
            }
        }
    }
}
