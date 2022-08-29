using WebModels;

namespace WebAppForAdmins.Models.Blogs
{
    public class BlogsViewModel
    {
        public IList<BlogModel> Blogs { get; set; } = default!;
    }
}
