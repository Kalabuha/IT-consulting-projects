using DataModels;

namespace RepositoryInterfaces
{
    public interface IMainPageTextRepository
    {
        public Task<MainPageTextDataModel?> GetMainPageTextAsync(int id);
        public Task<MainPageTextDataModel[]> GetAllMainPageTextsAsync();
        public Task<int> AddMainPageTextAsync(MainPageTextDataModel data);
        public Task<bool> UpdateMainPageTextAsync(MainPageTextDataModel data);
        public Task<bool> DeleteMainPageTextAsync(int id);
    }
}
