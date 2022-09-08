using RepositoryInterfaces;
using ServiceInterfaces;
using DataModels;

namespace ContentDataServices
{
    internal class BlogDataService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogDataService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogDataModel?> GetBlogDataByIdAsync(int id)
        {
            var blog = await _blogRepository.GetBlogAsync(id);

            return blog;
        }

        public async Task<List<BlogDataModel>> GetAllBlogDatasAsync()
        {
            var blogs = (await _blogRepository.GetAllBlogsAsync())
                .ToList();

            return blogs;
        }

        public async Task<List<BlogDataModel>> GetPublishedBlogDatasAsync()
        {
            var blogs = (await _blogRepository.GetAllBlogsAsync())
                .Where(b => b.IsPublished)
                .ToList();

            return blogs;
        }

        public async Task AddBlogToDbAsync(BlogDataModel? data)
        {
            if (data != null)
            {
                data.PublicationDate = DateTime.Now;
                await _blogRepository.AddBlogAsync(data);
            }
        }

        public async Task EditBlogToDbAsync(BlogDataModel? data)
        {
            if (data != null)
            {
                await _blogRepository.UpdateBlogAsync(data);
            }
        }

        public async Task RemoveBlogToDbAsync(int id)
        {
            if (id > 0)
            {
                await _blogRepository.DeleteBlogAsync(id);
            }
        }
    }
}
