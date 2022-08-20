using WpfAppForEmployees.ViewModels.Base;
using WpfAppForEmployees.ViewModels.Main.Tabs;

namespace WpfAppForEmployees.ViewModels.Main
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel(
            ApplicationsTabModel applicationsTabModel,
            ProjectsTabModel projectsTabModel,
            BlogsTabModel blogsTabModel,
            ServicesTabModel servicesTabModel)
        {
            ApplicationsTabModel = applicationsTabModel;
            ProjectsTabModel = projectsTabModel;
            BlogsTabModel = blogsTabModel;
            ServicesTabModel = servicesTabModel;
        }

        public ApplicationsTabModel ApplicationsTabModel { get; set; }
        public ProjectsTabModel ProjectsTabModel { get; set; }
        public BlogsTabModel BlogsTabModel { get; set; }
        public ServicesTabModel ServicesTabModel { get; set; }

        public string Title { get; set; } = "Главное окно";

        public string Data { get; set; } = "какой-то текст";
    }
}
