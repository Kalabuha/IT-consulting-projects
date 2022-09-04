using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using ServiceInterfaces;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ApplicationsTabViewModel : BaseTabViewModel<ApplicationData>
    {
        private readonly IApplicationService _applicationService;
        public ApplicationsTabViewModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
    }
}
