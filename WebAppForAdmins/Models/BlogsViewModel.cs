using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class BlogsViewModel
    {
        public IList<BlogModel> Blogs { get; set; } = default!;
    }
}
