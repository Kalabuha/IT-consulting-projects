using System.Windows.Controls;
using WpfAppForEmployees.ViewModels.TabViewModels;

namespace WpfAppForEmployees.Views.MainWindowTabs
{
    /// <summary>
    /// Interaction logic for ApplicationsTabBodyControl.xaml
    /// </summary>
    public partial class ApplicationsTabControl : UserControl
    {
        public ApplicationsTabControl()
        {
            InitializeComponent();
            this.Loaded += ApplicationsTabControl_Loaded;
        }

        private async void ApplicationsTabControl_Loaded(object? sender, System.EventArgs e)
        {
            var viewModel = (ApplicationsTabViewModel)this.DataContext;
            await viewModel.LoadData();
        }
    }
}
