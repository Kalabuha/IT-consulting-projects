using System.Threading.Tasks;
using WebAppDataApi.Client;
using WpfAppForEmployees.ViewModels.Base;

namespace WpfAppForEmployees.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        //private readonly IApplicationsApi api;

        public string Title { get; set; } = "asd";
        public string Data { get; set; } = "какой-то текст";
        public string GuestName { get; set; } = "asd";


        public MainWindowViewModel()
        {
            Title = "Главное окно";
            //this.api = api;
        }
        
        //public async Task Load()
        //{
        //    var result = await api.Get();
        //    GuestName = result.GuestName;
        //}
    }
}
