using WpfAppForEmployees.ViewModels.Base;
using System.Collections.ObjectModel;
using WpfModels.Base;

namespace WpfAppForEmployees.ViewModels.TabViewModels.Base
{
    public abstract class BaseTabViewModel<TWpfModel> : BaseViewModel where TWpfModel : BaseWpfModel
    {
        public BaseTabViewModel()
        {
            _tabDataModels = new ObservableCollection<TWpfModel>();
        }

        private ObservableCollection<TWpfModel> _tabDataModels;
        public ObservableCollection<TWpfModel> TabDataCollection
        {
            get => _tabDataModels; 
            set => Set(ref _tabDataModels, value);
        }
    }
}
