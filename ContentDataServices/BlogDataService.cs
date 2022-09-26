using RepositoryInterfaces;
using ServiceInterfaces;
using DataModels;

namespace ContentDataServices
{
    internal class BlogDataService : IBlogService
    {
        private readonly IRepository<BlogDataModel> _blogRepository;

        public BlogDataService(IRepository<BlogDataModel> blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogDataModel?> GetBlogDataByIdAsync(int id)
        {
            var blog = await _blogRepository.GetDataModelAsync(id);

            return blog;
        }

        public async Task<List<BlogDataModel>> GetAllBlogDatasAsync()
        {
            var blogs = (await _blogRepository.GetAllDataModelsAsync())
                .ToList();

            return blogs;
        }

        public async Task<List<BlogDataModel>> GetPublishedBlogDatasAsync()
        {
            var blogs = (await _blogRepository.GetAllDataModelsAsync())
                .Where(b => b.IsPublished)
                .ToList();

            return blogs;
        }

        public async Task AddBlogToDbAsync(BlogDataModel? data)
        {
            if (data != null)
            {
                data.PublicationDate = DateTime.Now;
                await _blogRepository.AddDataModelAsync(data);
            }
        }

        public async Task<bool> EditBlogToDbAsync(BlogDataModel? data)
        {
            if (data != null)
            {
                return await _blogRepository.UpdateDataModelAsync(data);
            }

            return false;
        }

        public async Task<bool> RemoveBlogToDbAsync(int id)
        {
            if (id > 0)
            {
                return await _blogRepository.DeleteDataModelAsync(id);
            }

            return false;
        }

        public async Task<bool> RemoveBlogToDbAsync(BlogDataModel? data)
        {
            return await RemoveBlogToDbAsync(data != null ? data.Id : 0);
        }
    }
}
