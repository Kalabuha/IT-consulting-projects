using DataModels;
using Enums;

namespace ServiceInterfaces
{
    public interface IApplicationService
    {
        Task<List<ApplicationDataModel>> GetAllApplicationsDataAsync();
        Task<List<ApplicationDataModel>> GetFilteredApplicationDatas(ApplicationStatus[] statuses, DateTime start, DateTime end);
        Task<ApplicationDataModel?> GetApplicationDataById(int id);
        Task<int> AddApplicationToDbAsync(ApplicationDataModel? data);
        Task<bool> EditApplicationToDb(ApplicationDataModel? data);

    }
}
