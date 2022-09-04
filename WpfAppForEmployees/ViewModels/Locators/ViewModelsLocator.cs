using Microsoft.Extensions.DependencyInjection;
using WpfAppForEmployees.ViewModels.TabViewModels;

namespace WpfAppForEmployees.ViewModels.Locators
{
    public class ViewModelsLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
        public ApplicationsTabViewModel ApplicationsTabViewModel => App.Host.Services.GetRequiredService<ApplicationsTabViewModel>();
        public ProjectsTabViewModel ProjectsTabViewModel => App.Host.Services.GetRequiredService<ProjectsTabViewModel>();
        public ServicesTabViewModel ServicesTabViewModel => App.Host.Services.GetRequiredService<ServicesTabViewModel>();
        public BlogsTabViewModel BlogsTabViewModel => App.Host.Services.GetRequiredService<BlogsTabViewModel>();
    }
}
