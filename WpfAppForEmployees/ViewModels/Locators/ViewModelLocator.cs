using Microsoft.Extensions.DependencyInjection;
using WpfAppForEmployees.ViewModels.Main;

namespace WpfAppForEmployees.ViewModels.Locators
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();

    }
}
