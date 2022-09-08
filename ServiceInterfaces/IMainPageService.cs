using DataModels.Base;
using DataModels;

namespace ServiceInterfaces
{
    public interface IMainPageService
    {
        public Task<List<MainPagePresetDataModel>> GetAllPresetDatasAsync();
        public Task<MainPagePresetDataModel?> GetPublishedPresetDataAsync();
        public Task<MainPagePresetDataModel?> GetPresetDataByIdAsync(int id);
        public Task PublishPresetAsync(int id);

        public Task<int> AddMainPagePresetToDbAsync(MainPagePresetDataModel? data);
        public Task EditMainPagePresetToDbAsync(MainPagePresetDataModel? data);
        public Task RemoveMainPagePresetToDbAsync(MainPagePresetDataModel? data);

        public Task<TMainPageData?> GetElementDataByIdAsync<TMainPageData>(int? id) where TMainPageData : BaseDataModel;
        public Task<TMainPageData?> GetElementDataByPresetIdAsync<TMainPageData>(int? id) where TMainPageData : BaseDataModel;
        public Task<List<TMainPageData>> GetAllElementDatasAsync<TMainPageData>() where TMainPageData : BaseDataModel;
        public Task DeleteElementToDbAsync<TMainPageData>(int id) where TMainPageData : BaseDataModel;
        public Task AddElementToDbAsync<TMainPageData>(TMainPageData data) where TMainPageData : BaseDataModel;

        public Task<MainPageTextDataModel> GetDefaultMainPageTextData();
        public Task<MainPageActionDataModel> GetDefaultMainPageActionData();
    }
}
