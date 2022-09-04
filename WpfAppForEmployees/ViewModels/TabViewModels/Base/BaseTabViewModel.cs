using WpfAppForEmployees.ViewModels.Base;
using DataModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfAppForEmployees.ViewModels.TabViewModels.Base
{
    public abstract class BaseTabViewModel<TData> : BaseViewModel where TData : BaseData
    {
        public BaseTabViewModel()
        {
            _tabDataModels = new ObservableCollection<TData>();
        }

        private ObservableCollection<TData> _tabDataModels;
        public ObservableCollection<TData> TabDataCollection
        {
            get => _tabDataModels; 
            set => Set(ref _tabDataModels, value);
        }

        #region Команда создать новую DataModel
        //public ICommand CrateNewDataModel { get; private set; } = default!;

        //private void OnExecuteCallCreateClientManagerWindowCommand(object parameter)
        //{
        //    var managmentClientWindow = new ManagerClientWindow()
        //    {
        //        Owner = Application.Current.MainWindow,
        //    };
        //    ManagerClientWindow = managmentClientWindow;
        //    managmentClientWindow.Closed += OnDialogWindowClosed!;

        //    var newClient = new ClientModel
        //    {
        //        Name = string.Empty,
        //        Surname = string.Empty,
        //        Patronymic = string.Empty,
        //        PassSeries = string.Empty,
        //        PassNumber = string.Empty,
        //        PhoneNumbers = new ObservableCollection<string>(),
        //        Accounts = new ObservableCollection<BankAccountModel>()
        //    };

        //    var managerClientWindowViewModel = new ManagerClientWindowViewModel(_clientsService, Localization, newClient);
        //    ManagerClientWindowViewModel = managerClientWindowViewModel;

        //    managerClientWindowViewModel.AddAction += _clientsService.AddClientAsync;
        //    managerClientWindowViewModel.isAddActionHandlerAttached = true;

        //    managerClientWindowViewModel.Status = Localization.StringLibrary[30];
        //    SetDataEditingRights(managerClientWindowViewModel);
        //    managmentClientWindow.DataContext = ManagerClientWindowViewModel;
        //    managmentClientWindow.ShowDialog();
        //}

        //private bool CanExecuteCallCreateClientManagerWindowCommand(object parameter)
        //{
        //    // Только менеджер может создавать нового клиента
        //    if (RegisteredUser != null && RegisteredUser.AccessLevel == EmployeeAccessLevel.Manager)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        #endregion

        #region Команда изменить выбранную DataModel
        //public ICommand EditClientCommand { get; private set; } = default!;

        //private void OnExecuteEditClientCommand(object parameter)
        //{
        //    var managmentClientWindow = new ManagerClientWindow()
        //    {
        //        Owner = Application.Current.MainWindow,
        //    };
        //    ManagerClientWindow = managmentClientWindow;
        //    managmentClientWindow.Closed += OnDialogWindowClosed!;

        //    var managerClientWindowViewModel = new ManagerClientWindowViewModel(_clientsService, Localization, SelectedClient!);
        //    ManagerClientWindowViewModel = managerClientWindowViewModel;

        //    managerClientWindowViewModel.UpdateAction += _clientsService.EditClientAsync;
        //    managerClientWindowViewModel.isUpdateActionHandlerAttached = true;

        //    managerClientWindowViewModel.Status = Localization.StringLibrary[55];
        //    SetDataEditingRights(managerClientWindowViewModel);
        //    managmentClientWindow.DataContext = ManagerClientWindowViewModel;
        //    managmentClientWindow.ShowDialog();
        //}

        //private bool CanExecuteEditClientCommand(object parameter)
        //{
        //    // Изменять может и консультант и менеджер. Но у консультанта урезаны возможности по изменению
        //    if (RegisteredUser != null && SelectedClient != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        #endregion

        #region Команда удалить выбранную DataModel
        //public ICommand DeleteClientCommand { get; private set; } = default!;

        //private void OnExecuteDeleteClientCommand(object parameter)
        //{
        //    var managmentClientWindow = new ManagerClientWindow()
        //    {
        //        Owner = Application.Current.MainWindow,
        //    };
        //    ManagerClientWindow = managmentClientWindow;
        //    managmentClientWindow.Closed += OnDialogWindowClosed!;

        //    var managerClientWindowViewModel = new ManagerClientWindowViewModel(_clientsService, Localization, SelectedClient!);
        //    ManagerClientWindowViewModel = managerClientWindowViewModel;

        //    managerClientWindowViewModel.DeleteAction += _clientsService.DeleteClientAsync;
        //    managerClientWindowViewModel.isDeleteActionHandlerAttached = true;

        //    managerClientWindowViewModel.Status = Localization.StringLibrary[56];
        //    SetDataEditingRights(managerClientWindowViewModel);
        //    managmentClientWindow.DataContext = ManagerClientWindowViewModel;
        //    managmentClientWindow.ShowDialog();
        //}

        //private bool CanExecuteDeleteClientCommand(object parameter)
        //{
        //    // Удалять может только менеджер
        //    if (RegisteredUser != null &&
        //        RegisteredUser.AccessLevel == EmployeeAccessLevel.Manager &&
        //        SelectedClient != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        #endregion
    }
}
