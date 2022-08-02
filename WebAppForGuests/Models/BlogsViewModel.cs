using Resources.Models;

namespace WebAppForGuests.Models
{
    public class BlogsViewModel
    {
        public BlogModel? SelectedBlog { get; set; }
        public List<BlogModel>? Blogs { get; set; }
    }
}
