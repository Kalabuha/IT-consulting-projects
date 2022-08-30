using DbRepositories.Interfaces;
using WebServices.Interfaces;
using EntitiesDataModelsConverters;
using DataModels;

namespace WebServices
{
    internal class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<ServiceData>> GetAllServiceDatasAsync()
        {
            var services = (await _serviceRepository.GetAllServiceEntitiesAsync())
                .Select(s => s.ServiceEntityToData())
                .ToList();

            return services;
        }

        public async Task<List<ServiceData>> GetPublishedServiceDatasAsync()
        {
            var services = (await _serviceRepository.GetAllServiceEntitiesAsync())
                .Where(s => s.IsPublished == true)
                .Select(s => s.ServiceEntityToData())
                .ToList();

            return services;
        }

        public async Task<ServiceData?> GetServiceDataByIdAsync(int serviceId)
        {
            var service = await _serviceRepository.GetEntity(serviceId);

            return service?.ServiceEntityToData();
        }

        public async Task AddServiceToDbAsync(ServiceData data)
        {
            var entity = data.ServiceDataToEntity();

            await _serviceRepository.AddEntityAsync(entity);
        }

        public async Task EditServiceToDbAsync(ServiceData data)
        {
            var entity = await _serviceRepository.GetEntity(data.Id);
            if (entity == null) throw new ArgumentException($"Не найдеа услуга {data.Id}.", nameof(data));

            data.ServiceDataToEntity(entity);

            await _serviceRepository.UpdateEntityAsync(entity);
        }

        public async Task RemoveServiceToDbAsync(int id)
        {
            var entity = await _serviceRepository.GetEntity(id);
            if (entity != null)
            {
                await _serviceRepository.RemoveEntityAsync(entity);
            }
        }
    }
}
