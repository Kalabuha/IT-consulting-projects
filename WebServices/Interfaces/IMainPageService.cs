using DataModels.Base;
using DataModels;

namespace WebServices.Interfaces
{
    public interface IMainPageService
    {
        public Task<List<MainPagePresetData>> GetAllPresetDatasAsync();
        public Task<MainPagePresetData?> GetPublishedPresetDataAsync();
        public Task<MainPagePresetData?> GetPresetDataByIdAsync(int id);
        public Task PublishPresetAsync(int id);

        public Task<int> CreatePresetAsync(MainPagePresetData data);
        public Task UpdatePresetAsync(MainPagePresetData data);
        public Task DeletePresetAsync(MainPagePresetData data);

        public Task<TMainPageData?> GetElementDataByIdAsync<TMainPageData>(int? id) where TMainPageData : BaseData;
        public Task<TMainPageData?> GetElementDataByPresetIdAsync<TMainPageData>(int? id) where TMainPageData : BaseData;
        public Task<List<TMainPageData>> GetAllElementDatasAsync<TMainPageData>() where TMainPageData : BaseData;
        public Task DeleteElementAsync<TMainPageData>(int id) where TMainPageData : BaseData;
        public Task CreateElementAsync<TMainPageData>(TMainPageData data) where TMainPageData : BaseData;

        public Task<MainPageTextData> GetDefaultMainPageTextData();
        public Task<MainPageActionData> GetDefaultMainPageActionData();

    }
}
