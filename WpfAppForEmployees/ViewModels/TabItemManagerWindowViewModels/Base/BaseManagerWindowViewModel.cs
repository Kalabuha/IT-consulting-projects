using System;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppForEmployees.ViewModels.Base;
using WpfAppForEmployees.WpfModels.Base;
using DataModels.Base;
using System.Windows;

namespace WpfAppForEmployees.ViewModels.TabItemManagerWindowViewModels.Base
{
    public abstract class BaseManagerWindowViewModel<TWpfModel, TDataModel> : BaseViewModel
        where TWpfModel : BaseWpfModel
        where TDataModel : BaseDataModel
    {
        public string Title { get; set; } = "Проект";

        public Func<TDataModel, Task>? ExecuteCudAction;
        public string ExecuteCudButtonContent { get; set; } = "Подтвердить";
        public bool IsEditingEnable { get; set; } = true;
        public Visibility SelectFileButtonVisibility => IsEditingEnable ? Visibility.Visible : Visibility.Hidden;
        public Visibility ResetCudButtonVisibility { get; set; } = Visibility.Visible;

        private TWpfModel? _managerItem;
        public TWpfModel? ManagerItem
        {
            get => _managerItem;
            set => Set(ref _managerItem, value);
        }

        public ICommand ExecuteCudActionCommand { get; set; } = default!;
        public ICommand ResetCudActionCommand { get; set; } = default!;

        protected void CloseTabItemManagerWindow(object parameter)
        {
            var window = (Window)parameter;
            window.Close();
        }
    }
}
