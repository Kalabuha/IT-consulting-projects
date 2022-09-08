using DataModels;

namespace RepositoryInterfaces
{
    public interface IBlogRepository
    {
        public Task<BlogDataModel?> GetBlogAsync(int id);
        public Task<BlogDataModel[]> GetAllBlogsAsync();
        public Task<int> AddBlogAsync(BlogDataModel data);
        public Task<bool> UpdateBlogAsync(BlogDataModel data);
        public Task<bool> DeleteBlogAsync(int id);
    }
}
