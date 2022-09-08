using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class BlogDbRepository : BaseDbRepository<BlogEntity>, IBlogRepository
    {
        public BlogDbRepository(DbContextProfiСonnector context) : base(context) { }

        public async Task<BlogDataModel?> GetBlogAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            return entity?.BlogEntityToData();
        }

        public async Task<BlogDataModel[]> GetAllBlogsAsync()
        {
            var blogs = await Context.Blogs
                .Select(b => b.BlogEntityToData())
                .ToArrayAsync();

            return blogs;
        }

        public async Task<int> AddBlogAsync(BlogDataModel data)
        {
            var entity = data.BlogDataToEntity();
            await AddEntityAsync(entity);
            return entity.Id;
        }

        public async Task<bool> UpdateBlogAsync(BlogDataModel data)
        {
            var entity = await GetEntityAsync(data.Id);
            if (entity == null)
            {
                return false;
            }

            var updated = data.BlogDataToEntity(entity);
            await UpdateEntityAsync(updated);
            return true;
        }

        public async Task<bool> DeleteBlogAsync(int id)
        {
            var entity = await GetEntityAsync(id);
            if (entity == null)
            {
                return false;
            }

            await RemoveEntityAsync(entity);
            return true;
        }
    }
}
