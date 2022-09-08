using DataModels;

namespace RepositoryInterfaces
{
    public interface IHeaderMenuRepository
    {
        public Task<HeaderMenuDataModel?> GetHeaderMenuAsync(int id);
        public Task<HeaderMenuDataModel[]> GetAllHeaderMenusAsync();
        public Task<int> AddHeaderMenuAsync(HeaderMenuDataModel data);
        public Task<bool> UpdateHeaderMenuAsync(HeaderMenuDataModel data);
        public Task<bool> DeleteHeaderMenuAsync(int id);
    }
}
