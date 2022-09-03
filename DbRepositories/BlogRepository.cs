using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using Entities;

namespace DbRepositories
{
    internal class BlogRepository : BaseRepository<BlogEntity>, IBlogRepository
    {
        public BlogRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<BlogEntity[]> GetAllBlogEntitiesAsync()
        {
            var blogs = await Context.Blogs
                .ToArrayAsync();

            return blogs;
        }
    }
}
