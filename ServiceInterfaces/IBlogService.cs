using DataModels;

namespace ServiceInterfaces
{
    public interface IBlogService
    {
        public Task<List<BlogData>> GetAllBlogDatasAsync();
        public Task<List<BlogData>> GetPublishedBlogDatasAsync();
        public Task<BlogData?> GetBlogDataByIdAsync(int projectId);

        public Task AddBlogToDbAsync(BlogData data);
        public Task EditBlogToDbAsync(BlogData data);
        public Task RemoveBlogToDbAsync(int id);
    }
}
