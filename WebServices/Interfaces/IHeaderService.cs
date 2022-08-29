using DataModels;

namespace WebServices.Interfaces
{
    public interface IHeaderService
    {
        public Task<List<MenuData>> GetAllMenuDatasAsync();
        public Task<MenuData> GetUsedMenuDataAsync();
        public Task StartUsingMenuAsync(int id);
        public Task AddMenuToDbAsync(MenuData data);
        public Task EditMenuToDbAsync(MenuData data);
        public Task RemoveMenuToDbAsync(int id);

        public Task<SloganData> GetRandomSloganDataAsync();
        public Task<List<SloganData>> GetAllSloganDatasAsync();
        public Task<string> GetDefaultSloganContent();

        public Task StartUsingSlogansAsync(int[] slogansId);
        public Task<SloganData?> GetSloganDataByIdAsync(int id);
        public Task AddSloganToDbAsync(SloganData data);
        public Task EditSloganToDbAsync(SloganData data);
        public Task RemoveSloganToDbAsync(int id);


    }
}
