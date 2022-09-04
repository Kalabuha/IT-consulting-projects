using RepositoryInterfaces;
using ServiceInterfaces;
using EntitiesDataModelsConverters;
using DataModels;
using Enums;

namespace ContentDataServices
{
    internal class ApplicationDataService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationDataService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<List<ApplicationData>> GetAllApplicationsDataAsync()
        {
            var applications = (await _applicationRepository.GetAllApplicationEntitiesAsync())
                .Select(a => a.ApplicationEntityToData())
                .ToList();

            return applications;
        }

        public async Task<List<ApplicationData>> GetFilteredApplicationDatas(ApplicationStatus[] statuses, DateTime start, DateTime end)
        {
            if (statuses == null || statuses.Length == 0 || start >= end)
            {
                return new List<ApplicationData>();
            }

            var applications = (await _applicationRepository.GetAllApplicationEntitiesAsync())
                .Where(a => statuses.Contains(a.Status) && start <= a.DateReceipt && a.DateReceipt <= end)
                .Select(a => a.ApplicationEntityToData())
                .ToList();

            return applications;
        }

        public async Task<ApplicationData?> GetApplicationDataById(int id)
        {
            var application = (await _applicationRepository.GetAllApplicationEntitiesAsync())
                .FirstOrDefault(a => a.Id == id);

            return application?.ApplicationEntityToData();
        }

        public async Task<int> AddApplicationToDb(ApplicationData data)
        {
            if (CheckApplication(data))
            {
                return 0;
            }

            var entity = data.ApplicationDataToEntity();
            await _applicationRepository.AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task UpdateApplicationToDb(ApplicationData data)
        {
            if (CheckApplication(data))
            {
                return;
            }

            var entity = await _applicationRepository.GetEntityAsync(data.Id);
            if (entity == null)
            {
                return;
            }

            var newModel = data.ApplicationDataToEntity(entity);
            await _applicationRepository.UpdateEntityAsync(newModel);
        }

        private bool CheckApplication(ApplicationData data)
        {
            if (string.IsNullOrEmpty(data.GuestName) ||
                string.IsNullOrEmpty(data.GuestEmail) ||
                string.IsNullOrEmpty(data.GuestApplicationText))
            {
                return true;
            }

            return false;
        }
    }
}
