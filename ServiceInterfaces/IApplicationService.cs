using DataModels;
using Enums;

namespace ServiceInterfaces
{
    public interface IApplicationService
    {
        public Task<List<ApplicationDataModel>> GetAllApplicationsDataAsync();
        public Task<List<ApplicationDataModel>> GetFilteredApplicationDatas(ApplicationStatus[] statuses, DateTime start, DateTime end);
        public Task<ApplicationDataModel?> GetApplicationDataById(int id);
        public Task<int> AddApplicationToDbAsync(ApplicationDataModel? data);
        public Task EditApplicationToDb(ApplicationDataModel? data);

    }
}
