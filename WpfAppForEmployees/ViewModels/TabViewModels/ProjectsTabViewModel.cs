using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ServiceInterfaces;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ProjectsTabViewModel : BaseTabViewModel<ProjectDataModel>
    {
        private readonly IProjectService _projectService;
        public ProjectsTabViewModel(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task LoadData()
        {
            var projects = await _projectService.GetAllProjectDatasAsync();
            TabDataCollection = new ObservableCollection<ProjectDataModel>(projects);
        }
    }
}
