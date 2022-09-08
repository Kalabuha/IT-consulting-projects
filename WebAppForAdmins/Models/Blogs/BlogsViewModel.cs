using WebModels;

namespace WebAppForAdmins.Models.Blogs
{
    public class BlogsViewModel
    {
        public IList<BlogWebModel> Blogs { get; set; } = default!;
    }
}
