using Entities;

namespace DbRepositories.Interfaces
{
    public interface IMainPagePhraseRepository : IRepository<MainPagePhraseEntity>
    {
        public Task<MainPagePhraseEntity[]> GetAllMainPagePhraseEntitiesAsync();
    }
}
