using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using ServiceInterfaces;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class BlogsTabViewModel : BaseTabViewModel<BlogData>
    {
        private readonly IBlogService _blogService;
        public BlogsTabViewModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
    }
}
