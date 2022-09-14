using DataModels;

namespace ServiceInterfaces
{
    public interface IHeaderService
    {
        public Task<List<HeaderMenuDataModel>> GetAllHeaderMenuDatasAsync();
        public Task<HeaderMenuDataModel> GetUsedHeaderMenuDataAsync();
        public Task StartUsingHeaderMenuAsync(int id);
        public Task AddMenuToDbAsync(HeaderMenuDataModel data);
        public Task EditMenuToDbAsync(HeaderMenuDataModel data);
        public Task RemoveMenuToDbAsync(int id);

        public Task<HeaderSloganDataModel> GetRandomOrDefaultHeaderSloganDataAsync(string startPathToDefaultData);
        public Task<List<HeaderSloganDataModel>> GetAllHeaderSloganDatasAsync();
        public Task<string> GetDefaultSloganContent(string startPathToDefaultData);

        public Task StartUsingHeaderSlogansAsync(int[] slogansId);
        public Task<HeaderSloganDataModel?> GetHeaderSloganDataByIdAsync(int id);
        public Task AddSloganToDbAsync(HeaderSloganDataModel data);
        public Task EditSloganToDbAsync(HeaderSloganDataModel data);
        public Task RemoveSloganToDbAsync(int id);
    }
}
