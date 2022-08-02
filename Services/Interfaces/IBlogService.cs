using Resources.Datas;

namespace Services.Interfaces
{
    public interface IBlogService
    {
        public Task<List<BlogData>> GetAllBlogModelsAsync();
        public Task<List<BlogData>> GetPublishedBlogModelsAsync();
        public Task<BlogData?> GetBlogByIdAsync(int projectId);

        public Task AddBlogToDbAsync(BlogData data);
        public Task EditBlogToDbAsync(BlogData data);
        public Task RemoveBlogToDbAsync(int id);
    }
}
