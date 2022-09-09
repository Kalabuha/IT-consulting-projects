using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using WpfAppForEmployees.DataModelsWpfModelsMappers;
using ServiceInterfaces;
using WpfAppForEmployees.WpfModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class BlogsTabViewModel : BaseTabViewModel<BlogWpfModel>
    {
        private readonly IBlogService _blogService;
        public BlogsTabViewModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task LoadData()
        {
            var blogs = (await _blogService.GetAllBlogDatasAsync())
                .Select(b => b.BlogDataModelToWpfModel());

            TabItems = new ObservableCollection<BlogWpfModel>(blogs);
        }
    }
}
