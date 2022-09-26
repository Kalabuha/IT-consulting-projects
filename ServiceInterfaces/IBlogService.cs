using DataModels;

namespace ServiceInterfaces
{
    public interface IBlogService
    {
        Task<List<BlogDataModel>> GetAllBlogDatasAsync();
        Task<List<BlogDataModel>> GetPublishedBlogDatasAsync();
        Task<BlogDataModel?> GetBlogDataByIdAsync(int id);

        Task AddBlogToDbAsync(BlogDataModel? data);
        Task<bool> EditBlogToDbAsync(BlogDataModel? data);
        Task<bool> RemoveBlogToDbAsync(int id);
        Task<bool> RemoveBlogToDbAsync(BlogDataModel? data);

    }
}
