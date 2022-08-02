using Resources.Entities;

namespace Repositories.Interfaces
{
    public interface IBlogRepository : IRepository<BlogEntity>
    {
        public Task<BlogEntity[]> GetAllBlogEntitiesAsync();
    }
}
