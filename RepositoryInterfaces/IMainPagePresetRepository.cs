using DataModels;

namespace RepositoryInterfaces
{
    public interface IMainPagePresetRepository
    {
        public Task<MainPagePresetDataModel?> GetMainPagePresetAsync(int id);
        public Task<MainPagePresetDataModel[]> GetAllMainPagePresetsAsync();
        public Task<int> AddMainPagePresetAsync(MainPagePresetDataModel data);
        public Task<bool> UpdateMainPagePresetAsync(MainPagePresetDataModel data);
        public Task<bool> DeleteMainPagePresetAsync(int id);
    }
}
