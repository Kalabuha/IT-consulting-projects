using Entities;

namespace DbRepositories.Interfaces
{
    public interface IBlogRepository : IRepository<BlogEntity>
    {
        public Task<BlogEntity[]> GetAllBlogEntitiesAsync();
    }
}
