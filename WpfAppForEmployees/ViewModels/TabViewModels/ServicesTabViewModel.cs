using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using ServiceInterfaces;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ServicesTabViewModel : BaseTabViewModel<ServiceData>
    {
        private readonly IServiceService _serviceService;
        public ServicesTabViewModel(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
    }
}
