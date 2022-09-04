using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class BlogDbRepository : BaseDbRepository<BlogEntity>, IBlogRepository
    {
        public BlogDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<BlogEntity[]> GetAllBlogEntitiesAsync()
        {
            var blogs = await Context.Blogs
                .ToArrayAsync();

            return blogs;
        }
    }
}
