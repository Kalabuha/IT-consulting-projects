using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using WpfAppForEmployees.DataModelsWpfModelsMappers;
using ServiceInterfaces;
using WpfAppForEmployees.WpfModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ProjectsTabViewModel : BaseTabViewModel<ProjectWpfModel>
    {
        private readonly IProjectService _projectService;
        public ProjectsTabViewModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task LoadData()
        {
            var projects = (await _projectService.GetAllProjectDatasAsync())
                .Select(p => p.ProjectDataModelToWpfModel());

            TabItems = new ObservableCollection<ProjectWpfModel>(projects);
        }
    }
}
