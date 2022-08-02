using Resources.Models;
using Resources.Enums;

namespace Services.Interfaces
{
    public interface IApplicationService
    {
        public Task<List<ApplicationModel>> GetAllApplicationsAsync();
        public Task<ApplicationModel?> GetApplicationByID(int id);
        public Task<int> AddApplicationToDb(ApplicationModel newApplication);
        public Task<List<ApplicationModel>> GetFilteredApplications(ApplicationStatus[] statuses, DateTime start, DateTime end);
    }
}
