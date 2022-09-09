using WpfAppForEmployees.ViewModels.Base;
using System.Collections.ObjectModel;
using WpfAppForEmployees.WpfModels.Base;

namespace WpfAppForEmployees.ViewModels.TabViewModels.Base
{
    public abstract class BaseTabViewModel<TWpfModel> : BaseViewModel where TWpfModel : BaseWpfModel
    {
        public BaseTabViewModel()
        {
            _tabItems = new ObservableCollection<TWpfModel>();
        }

        private ObservableCollection<TWpfModel> _tabItems;
        public ObservableCollection<TWpfModel> TabItems
        {
            get => _tabItems; 
            set => Set(ref _tabItems, value);
        }

        private TWpfModel? _selectedTabItem;
        public TWpfModel? SelectedTabItem
        {
            get => _selectedTabItem;
            set => Set(ref _selectedTabItem, value);
        }
    }
}
