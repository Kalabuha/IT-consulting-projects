using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IMainPagePhraseRepository : IRepository<MainPagePhraseEntity>
    {
        public Task<MainPagePhraseEntity[]> GetAllMainPagePhraseEntitiesAsync();
    }
}
