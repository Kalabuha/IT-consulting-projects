using RepositoryInterfaces;
using ServiceInterfaces;
using DataModels;
using Enums;

namespace ContentDataServices
{
    internal class ApplicationDataService : IApplicationService
    {
        private readonly IRepository<ApplicationDataModel> _applicationRepository;

        public ApplicationDataService(IRepository<ApplicationDataModel> applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<List<ApplicationDataModel>> GetAllApplicationsDataAsync()
        {
            var applications = (await _applicationRepository.GetAllDataModelsAsync())
                .ToList();

            return applications;
        }

        public async Task<List<ApplicationDataModel>> GetFilteredApplicationDatas(ApplicationStatus[] statuses, DateTime start, DateTime end)
        {
            if (statuses == null || statuses.Length == 0 || start >= end)
            {
                return new List<ApplicationDataModel>();
            }

            var applications = (await _applicationRepository.GetAllDataModelsAsync())
                .Where(a => statuses.Contains(a.Status) && start <= a.DateReceiptApplication && a.DateReceiptApplication <= end)
                .ToList();

            return applications;
        }

        public async Task<ApplicationDataModel?> GetApplicationDataById(int id)
        {
            var application = await _applicationRepository.GetDataModelAsync(id);

            return application;
        }

        public async Task<int> AddApplicationToDbAsync(ApplicationDataModel? data)
        {
            if (data != null)
            {
                var newApplication = await _applicationRepository.AddDataModelAsync(data);
                return newApplication.Number;
            }

            return 0;
        }

        public async Task<bool> EditApplicationToDb(ApplicationDataModel? data)
        {
            if (data != null)
            {
                return await _applicationRepository.UpdateDataModelAsync(data);
            }

            return false;
        }
    }
}
