using WebModels;

namespace WebAppForGuests.Models
{
    public class BlogsViewModel
    {
        public BlogWebModel? SelectedBlog { get; set; }
        public List<BlogWebModel>? Blogs { get; set; }
    }
}
