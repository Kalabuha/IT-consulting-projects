using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Base;
using Resources.Entities;
using DbContextProfi;

namespace Repositories
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
