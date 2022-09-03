using System.Threading.Tasks;
using WebAppDataApi.Client;
using WpfAppForEmployees.ViewModels.Base;

namespace WpfAppForEmployees.ViewModels.Main
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IApplicationsApi api;

        public string Title { get; set; } = "Главное окно";

        public string Data { get; set; } = "какой-то текст";


        public MainWindowViewModel(IApplicationsApi api)
        {
            this.api = api;
        }

        
        public async Task Load()
        {
            var result = await api.Get();
            Title = result.GuestName;
        }
    }
}
