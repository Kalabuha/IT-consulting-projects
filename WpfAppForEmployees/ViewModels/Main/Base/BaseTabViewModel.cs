using WpfAppForEmployees.ViewModels.Base;
using DataModels.Base;
using System.Collections.ObjectModel;

namespace WpfAppForEmployees.ViewModels.Main.Base
{
    public abstract class BaseTabViewModel<TData> : BaseViewModel where TData : BaseData
    {
        public BaseTabViewModel()
        {
            _tabDataCollection = new ObservableCollection<TData>();
        }

        private ObservableCollection<TData> _tabDataCollection;
        public ObservableCollection<TData> TabDataCollection
        {
            get => _tabDataCollection; 
            set => Set(ref _tabDataCollection, value);
        }


    }
}
