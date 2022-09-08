using RepositoryInterfaces;
using ServiceInterfaces;
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

        public async Task<List<ApplicationDataModel>> GetAllApplicationsDataAsync()
        {
            var applications = (await _applicationRepository.GetAllApplicationAsync())
                .ToList();

            return applications;
        }

        public async Task<List<ApplicationDataModel>> GetFilteredApplicationDatas(ApplicationStatus[] statuses, DateTime start, DateTime end)
        {
            if (statuses == null || statuses.Length == 0 || start >= end)
            {
                return new List<ApplicationDataModel>();
            }

            var applications = (await _applicationRepository.GetAllApplicationAsync())
                .Where(a => statuses.Contains(a.Status) && start <= a.DateReceiptApplication && a.DateReceiptApplication <= end)
                .ToList();

            return applications;
        }

        public async Task<ApplicationDataModel?> GetApplicationDataById(int id)
        {
            var application = await _applicationRepository.GetApplicationAsync(id);

            return application;
        }

        public async Task<int> AddApplicationToDbAsync(ApplicationDataModel? data)
        {
            if (data != null)
            {
                var applicationNumber = await _applicationRepository.AddApplicationAsync(data);
                return applicationNumber;
            }

            return 0;
        }

        public async Task EditApplicationToDb(ApplicationDataModel? data)
        {
            if (data != null)
            {
                await _applicationRepository.UpdateApplicationAsync(data);
            }
        }
    }
}
