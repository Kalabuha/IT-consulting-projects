using DataModels;

namespace RepositoryInterfaces
{
    public interface IMainPagePhraseRepository
    {
        public Task<MainPagePhraseDataModel?> GetMainPagePhraseAsync(int id);
        public Task<MainPagePhraseDataModel[]> GetAllMainPagePhrasesAsync();
        public Task<int> AddMainPagePhraseAsync(MainPagePhraseDataModel data);
        public Task<bool> UpdateMainPagePhraseAsync(MainPagePhraseDataModel data);
        public Task<bool> DeleteMainPagePhraseAsync(int id);
    }
}
