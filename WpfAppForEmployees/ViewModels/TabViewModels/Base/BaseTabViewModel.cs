using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WpfAppForEmployees.ViewModels.Base;
using WpfAppForEmployees.WpfModels.Base;
using WpfAppForEmployees.Commands;

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

        public ICommand CreateTabItemCommand { get; set; } = default!;
        public ICommand EditTabItemCommand { get; set; } = default!;
        public ICommand RemoveTabItemCommand { get; set; } = default!;
    }
}
