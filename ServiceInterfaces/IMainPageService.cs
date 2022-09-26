using DataModels.Base;
using DataModels;

namespace ServiceInterfaces
{
    public interface IMainPageService
    {
        Task<List<MainPagePresetDataModel>> GetAllPresetDatasAsync();
        Task<MainPagePresetDataModel?> GetPublishedPresetDataAsync();
        Task<MainPagePresetDataModel?> GetPresetDataByIdAsync(int id);
        Task PublishPresetAsync(int id);

        Task<int> AddMainPagePresetToDbAsync(MainPagePresetDataModel? data);
        Task EditMainPagePresetToDbAsync(MainPagePresetDataModel? data);
        Task RemoveMainPagePresetToDbAsync(MainPagePresetDataModel? data);

        Task<TMainPageData?> GetElementDataByIdAsync<TMainPageData>(int? id) where TMainPageData : BaseDataModel;
        Task<TMainPageData?> GetElementDataByPresetIdAsync<TMainPageData>(int? id) where TMainPageData : BaseDataModel;
        Task<List<TMainPageData>> GetAllElementDatasAsync<TMainPageData>() where TMainPageData : BaseDataModel;
        Task DeleteElementToDbAsync<TMainPageData>(int id) where TMainPageData : BaseDataModel;
        Task AddElementToDbAsync<TMainPageData>(TMainPageData data) where TMainPageData : BaseDataModel;

        Task<MainPageTextDataModel> GetDefaultMainPageTextData(string startPathToDefaultData);
        Task<MainPageActionDataModel> GetDefaultMainPageActionData(string startPathToDefaultData);
    }
}
