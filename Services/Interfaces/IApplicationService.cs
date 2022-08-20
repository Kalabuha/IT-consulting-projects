using Resources.Models;
using Resources.Datas;
using Resources.Enums;

namespace Services.Interfaces
{
    public interface IApplicationService
    {
        public Task<List<ApplicationData>> GetAllApplicationsDataAsync();
        public Task<ApplicationData?> GetApplicationDataById(int id);
        public Task<int> AddApplicationToDb(ApplicationData data);
        public Task UpdateApplicationToDb(ApplicationData data);

        public Task<List<ApplicationData>> GetFilteredApplicationDatas(ApplicationStatus[] statuses, DateTime start, DateTime end);
    }
}
