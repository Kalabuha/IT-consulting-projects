using System.Windows.Controls;
using WpfAppForEmployees.ViewModels.TabViewModels;

namespace WpfAppForEmployees.Views.MainWindowTabs
{
    /// <summary>
    /// Interaction logic for BlogsTabBodyControl.xaml
    /// </summary>
    public partial class BlogsTabControl : UserControl
    {
        public BlogsTabControl()
        {
            InitializeComponent();
            this.Loaded += BlogsTabControl_Loaded;
        }

        private async void BlogsTabControl_Loaded(object? sender, System.EventArgs e)
        {
            var viewModel = (BlogsTabViewModel)this.DataContext;
            await viewModel.LoadData();
        }
    }
}
