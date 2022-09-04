using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using ServiceInterfaces;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ProjectsTabViewModel : BaseTabViewModel<ProjectData>
    {
        private readonly IProjectService _projectService;
        public ProjectsTabViewModel(IProjectService projectService)
        {
            _projectService = projectService;
        }
    }
}
