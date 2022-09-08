using DataModels;

namespace RepositoryInterfaces
{
    public interface IMainPageActionRepository
    {
        public Task<MainPageActionDataModel?> GetMainPageActionAsync(int id);
        public Task<MainPageActionDataModel[]> GetAllMainPageActionsAsync();
        public Task<int> AddMainPageActionAsync(MainPageActionDataModel data);
        public Task<bool> UpdateMainPageActionAsync(MainPageActionDataModel data);
        public Task<bool> DeleteMainPageActionAsync(int id);
    }
}