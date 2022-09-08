using System.Windows.Controls;
using WpfAppForEmployees.ViewModels.TabViewModels;

namespace WpfAppForEmployees.Views.MainWindowTabs
{
    /// <summary>
    /// Interaction logic for ServicesTabBodyControl.xaml
    /// </summary>
    public partial class ServicesTabControl : UserControl
    {
        public ServicesTabControl()
        {
            InitializeComponent();
            this.Loaded += ServicesTabControl_Loaded;
        }

        private async void ServicesTabControl_Loaded(object? sender, System.EventArgs e)
        {
            var viewModel = (ServicesTabViewModel)this.DataContext;
            await viewModel.LoadData();
        }
    }
}
