using Resources.Models;
using Resources.Enums;

namespace Services.Interfaces
{
    public interface IApplicationService
    {
        public Task<List<ApplicationModel>> GetAllApplicationsAsync();
        public Task<ApplicationModel?> GetApplicationById(int id);
        public Task<int> AddApplicationToDb(ApplicationModel model);
        public Task UpdateApplicationToDb(ApplicationModel model);

        public Task<List<ApplicationModel>> GetFilteredApplications(ApplicationStatus[] statuses, DateTime start, DateTime end);
    }
}
