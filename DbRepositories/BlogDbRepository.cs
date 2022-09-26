using Microsoft.EntityFrameworkCore;
using RepositoryInterfaces;
using DbRepositories.Base;
using DbContextProfi;
using EntitiesDataModelsMappers;
using DataModels;
using Entities;

namespace DbRepositories
{
    internal class BlogDbRepository : BaseDbRepository<BlogEntity, BlogDataModel>, IRepository<BlogDataModel>
    {
        public BlogDbRepository(DbContextProfiСonnector context)
            : base(context,
                  BlogEntityAndDataModelMapper.BlogEntityToData,
                  BlogEntityAndDataModelMapper.BlogDataToEntity)
        { }

        public async Task<BlogDataModel[]> GetAllDataModelsAsync()
        {
            var blogs = await Context.Blogs
                .Select(b => MapEntityToData(b))
                .ToArrayAsync();

            return blogs;
        }
    }
}
