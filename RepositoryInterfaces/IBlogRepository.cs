using Entities;

namespace RepositoryInterfaces
{
    public interface IBlogRepository : IRepository<BlogEntity>
    {
        public Task<BlogEntity[]> GetAllBlogEntitiesAsync();
    }
}
