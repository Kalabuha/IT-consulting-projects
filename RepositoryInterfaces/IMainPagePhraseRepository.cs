using Entities;

namespace RepositoryInterfaces
{
    public interface IMainPagePhraseRepository : IRepository<MainPagePhraseEntity>
    {
        public Task<MainPagePhraseEntity[]> GetAllMainPagePhraseEntitiesAsync();
    }
}
