using System.Windows.Controls;
using WpfAppForEmployees.ViewModels.TabViewModels;
using System.Windows.Input;

namespace WpfAppForEmployees.Views.MainWindowTabs
{
    /// <summary>
    /// Interaction logic for ProjectsTabBodyControl.xaml
    /// </summary>
    public partial class ProjectsTabControl : UserControl
    {
        public ProjectsTabControl()
        {
            InitializeComponent();
            this.Loaded += ProjectsTabControl_Loaded;
        }

        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        private async void ProjectsTabControl_Loaded(object? sender, System.EventArgs e)
        {
            var viewModel = (ProjectsTabViewModel)this.DataContext;
            await viewModel.LoadData();
        }
    }
}
