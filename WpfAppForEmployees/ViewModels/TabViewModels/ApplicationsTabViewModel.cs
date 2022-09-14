using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using WpfAppForEmployees.DataModelsWpfModelsMappers;
using ServiceInterfaces;
using WpfAppForEmployees.WpfModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ApplicationsTabViewModel : BaseTabViewModel<ApplicationWpfModel>
    {
        private readonly IApplicationService _applicationService;
        public ApplicationsTabViewModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;

        }

        public async Task LoadData()
        {
            var applications = (await _applicationService.GetAllApplicationsDataAsync())
                .Select(a => a.ApplicationDataModelToWpfModel());

            TabItems = new ObservableCollection<ApplicationWpfModel>(applications);
        }


    }
}
