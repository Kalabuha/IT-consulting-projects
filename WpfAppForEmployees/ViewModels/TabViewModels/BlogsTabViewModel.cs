using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ServiceInterfaces;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class BlogsTabViewModel : BaseTabViewModel<BlogDataModel>
    {
        private readonly IBlogService _blogService;
        public BlogsTabViewModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task LoadData()
        {
            var blogs = await _blogService.GetAllBlogDatasAsync();
            TabDataCollection = new ObservableCollection<BlogDataModel>(blogs);
        }
    }
}
