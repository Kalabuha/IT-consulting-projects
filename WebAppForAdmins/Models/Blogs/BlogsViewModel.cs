using Resources.Models;

namespace WebAppForAdmins.Models.Blogs
{
    public class BlogsViewModel
    {
        public IList<BlogModel> Blogs { get; set; } = default!;
    }
}
