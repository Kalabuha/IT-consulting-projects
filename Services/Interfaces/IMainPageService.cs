using Resources.Datas;
using Resources.Datas.Base;

namespace Services.Interfaces
{
    public interface IMainPageService
    {
        public Task<List<MainPagePresetData>> GetAllPresetDatasAsync();
        public Task<MainPagePresetData?> GetPublishedPresetDataAsync();
        public Task<MainPagePresetData?> GetPresetDataByIdAsync(int id);
        public Task PublishPreset(int id);

        public Task<int> CreatePreset(MainPagePresetData data);
        public Task UpdatePreset(MainPagePresetData data);
        public Task DeletePreset(MainPagePresetData data);

        public Task<TMainPageData?> GetElementDataByIdAsync<TMainPageData>(int? id) where TMainPageData : BaseData;
        public Task<TMainPageData?> GetElementDataByPresetIdAsync<TMainPageData>(int? id) where TMainPageData : BaseData;
        public Task<List<TMainPageData>> GetAllElementDatasAsync<TMainPageData>() where TMainPageData : BaseData;

        public Task<MainPageTextData> GetDefaultMainPageTextData();
        public Task<MainPageActionData> GetDefaultMainPageActionData();

    }
}
