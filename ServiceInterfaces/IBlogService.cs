using DataModels;

namespace ServiceInterfaces
{
    public interface IBlogService
    {
        public Task<List<BlogDataModel>> GetAllBlogDatasAsync();
        public Task<List<BlogDataModel>> GetPublishedBlogDatasAsync();
        public Task<BlogDataModel?> GetBlogDataByIdAsync(int id);

        public Task AddBlogToDbAsync(BlogDataModel? data);
        public Task EditBlogToDbAsync(BlogDataModel? data);
        public Task RemoveBlogToDbAsync(int id);
        public Task RemoveBlogToDbAsync(BlogDataModel? data);

    }
}
