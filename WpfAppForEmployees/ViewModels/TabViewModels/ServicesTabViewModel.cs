using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using WpfAppForEmployees.DataModelsWpfModelsMappers;
using ServiceInterfaces;
using WpfAppForEmployees.WpfModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ServicesTabViewModel : BaseTabViewModel<ServiceWpfModel>
    {
        private readonly IServiceService _serviceService;
        public ServicesTabViewModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task LoadData()
        {
            var services = (await _serviceService.GetAllServiceDatasAsync())
                .Select(s => s.ServiceDataModelToWpfModel());

            TabItems = new ObservableCollection<ServiceWpfModel>(services);
        }
    }
}
