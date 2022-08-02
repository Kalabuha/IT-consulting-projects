using Repositories.Interfaces;
using Resources.Models;
using Resources.Enums;
using Services.Converters;
using Services.Interfaces;

namespace Services
{
    internal class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<List<ApplicationModel>> GetAllApplicationsAsync()
        {
            var applications = (await _applicationRepository.GetApplicationsAsync())
                .Select(a => a.ApplicationEntityToModel())
                .ToList();

            return applications;
        }

        public async Task<List<ApplicationModel>> GetFilteredApplications(ApplicationStatus[] statuses, DateTime start, DateTime end)
        {
            if (statuses == null || statuses.Length == 0 || start >= end)
            {
                return new List<ApplicationModel>();
            }

            var applications = (await _applicationRepository.GetApplicationsAsync())
                .Where(a => statuses.Contains(a.Status) && start <= a.DateReceipt && a.DateReceipt <= end)
                .Select(a => a.ApplicationEntityToModel())
                .ToList();

            return applications;
        }

        public async Task<ApplicationModel?> GetApplicationByID(int id)
        {
            var application = (await _applicationRepository.GetApplicationsAsync())
                .FirstOrDefault(a => a.Id == id);

            return application?.ApplicationEntityToModel();
        }

        public async Task<int> AddApplicationToDb(ApplicationModel newApplication)
        {
            if (newApplication == null ||
                string.IsNullOrEmpty(newApplication.GuestName) ||
                string.IsNullOrEmpty(newApplication.GuestEmail) ||
                string.IsNullOrEmpty(newApplication.GuestApplicationText))
            {
                return 0;
            }

            var entity = newApplication.ApplicationModelToEntity();
            await _applicationRepository.AddEntityAsync(entity);
            return entity.Id;
        }

    }
}
