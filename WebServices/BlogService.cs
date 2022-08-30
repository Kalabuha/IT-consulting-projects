using DbRepositories.Interfaces;
using WebServices.Interfaces;
using EntitiesDataModelsConverters;
using DataModels;

namespace WebServices
{
    internal class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<List<BlogData>> GetAllBlogDatasAsync()
        {
            var blogs = (await _blogRepository.GetAllBlogEntitiesAsync())
                .Select(b => b.BlogEntityToData())
                .ToList();

            return blogs;
        }

        public async Task<List<BlogData>> GetPublishedBlogDatasAsync()
        {
            var blogs = (await _blogRepository.GetAllBlogEntitiesAsync())
                .Where(b => b.IsPublished == true)
                .Select(b => b.BlogEntityToData())
                .ToList();

            return blogs;
        }

        public async Task<BlogData?> GetBlogDataByIdAsync(int projectId)
        {
            var blog = await _blogRepository.GetEntity(projectId);

            return blog?.BlogEntityToData();
        }

        public async Task AddBlogToDbAsync(BlogData data)
        {
            data.PublicationDate = DateTime.Now;

            var entity = data.BlogDataToEntity();
            await _blogRepository.AddEntityAsync(entity);
        }

        public async Task EditBlogToDbAsync(BlogData data)
        {
            var entity = await _blogRepository.GetEntity(data.Id);
            if (entity == null) throw new ArgumentException($"Не найден блог {data.Id}.", nameof(data));

            data.BlogDataToEntity(entity);
            await _blogRepository.UpdateEntityAsync(entity);
        }

        public async Task RemoveBlogToDbAsync(int id)
        {
            var entity = await _blogRepository.GetEntity(id);
            if (entity != null)
            {
                await _blogRepository.RemoveEntityAsync(entity);
            }
        }
    }
}
