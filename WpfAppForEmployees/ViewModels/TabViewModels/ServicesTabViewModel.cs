using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ServiceInterfaces;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ServicesTabViewModel : BaseTabViewModel<ServiceDataModel>
    {
        private readonly IServiceService _serviceService;
        public ServicesTabViewModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task LoadData()
        {
            var services = await _serviceService.GetAllServiceDatasAsync();
            TabDataCollection = new ObservableCollection<ServiceDataModel>(services);
        }
    }
}
