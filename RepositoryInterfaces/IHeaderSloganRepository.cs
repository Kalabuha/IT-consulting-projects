using DataModels;

namespace RepositoryInterfaces
{
    public interface IHeaderSloganRepository
    {
        public Task<HeaderSloganDataModel?> GetHeaderSloganAsync(int id);
        public Task<HeaderSloganDataModel[]> GetAllHeaderSlogansAsync();
        public Task<int> AddHeaderSloganAsync(HeaderSloganDataModel data);
        public Task<bool> UpdateHeaderSloganAsync(HeaderSloganDataModel data);
        public Task<bool> DeleteHeaderSloganAsync(int id);
    }
}
