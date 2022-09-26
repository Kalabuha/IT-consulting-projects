using DataModels;

namespace ServiceInterfaces
{
    public interface IHeaderService
    {
        Task<List<HeaderMenuDataModel>> GetAllHeaderMenuDatasAsync();
        Task<HeaderMenuDataModel> GetUsedOrDefaultHeaderMenuDataAsync();
        Task StartUsingHeaderMenuAsync(int id);
        Task AddMenuToDbAsync(HeaderMenuDataModel data);
        Task EditMenuToDbAsync(HeaderMenuDataModel data);
        Task RemoveMenuToDbAsync(int id);

        Task<HeaderSloganDataModel> GetRandomOrDefaultHeaderSloganDataAsync(string startPathToDefaultData);
        Task<List<HeaderSloganDataModel>> GetAllHeaderSloganDatasAsync();
        Task<string> GetDefaultSloganContent(string startPathToDefaultData);

        Task StartUsingHeaderSlogansAsync(int[] slogansId);
        Task<HeaderSloganDataModel?> GetHeaderSloganDataByIdAsync(int id);
        Task AddSloganToDbAsync(HeaderSloganDataModel data);
        Task EditSloganToDbAsync(HeaderSloganDataModel data);
        Task RemoveSloganToDbAsync(int id);
    }
}
