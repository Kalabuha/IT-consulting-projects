using DataModels;

namespace RepositoryInterfaces
{
    public interface IMainPageImageRepository
    {
        public Task<MainPageImageDataModel?> GetMainPageImageAsync(int id);
        public Task<MainPageImageDataModel[]> GetAllMainPageImagesAsync();
        public Task<int> AddMainPageImageAsync(MainPageImageDataModel data);
        public Task<bool> UpdateMainPageImageAsync(MainPageImageDataModel data);
        public Task<bool> DeleteMainPageImageAsync(int id);
    }
}
