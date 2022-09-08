using DataModels;

namespace RepositoryInterfaces
{
    public interface IMainPageButtonRepository
    {
        public Task<MainPageButtonDataModel?> GetMainPageButtonAsync(int id);
        public Task<MainPageButtonDataModel[]> GetAllMainPageButtonsAsync();
        public Task<int> AddMainPageButtonAsync(MainPageButtonDataModel data);
        public Task<bool> UpdateMainPageButtonAsync(MainPageButtonDataModel data);
        public Task<bool> DeleteMainPageButtonAsync(int id);
    }
}
