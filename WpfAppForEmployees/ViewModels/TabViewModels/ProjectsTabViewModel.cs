using System.Windows;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using ServiceInterfaces;
using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using WpfAppForEmployees.DataModelsWpfModelsMappers;
using WpfAppForEmployees.WpfModels;
using WpfAppForEmployees.Commands;
using WpfAppForEmployees.Views.TabItemManagerWindows;
using WpfAppForEmployees.ViewModels.TabItemManagerWindowViewModels;
using System;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabViewModels
{
    public class ProjectsTabViewModel : BaseTabViewModel<ProjectWpfModel>
    {
        private readonly IProjectService _projectService;

        private ProjectManagerWindow? _projectManagerWindow;
        private ProjectManagerWindowViewModel? _projectManagerWindowViewModel;

        public ProjectsTabViewModel(IProjectService projectService)
        {
            _projectService = projectService;

            CreateTabItemCommand = new ActionCommand(OnExecuteProjectCreate, CanExecuteProjectCreate);
            EditTabItemCommand = new ActionCommand(OnExecuteProjectEdit, CanExecuteProjectEdit);
            RemoveTabItemCommand = new ActionCommand(OnExecuteProjectRemove, CanExecuteProjectRemove);
        }

        public async Task LoadData()
        {
            var projects = (await _projectService.GetAllProjectDatasAsync())
                .Select(p => p.ProjectDataModelToWpfModel());

            TabItems = new ObservableCollection<ProjectWpfModel>(projects);
        }

        protected void OnExecuteProjectCreate(object parameter)
        {
            ShowDialogProjectManagerWindow(
                _projectService.AddProjectToDbAsync,
                "Создание проекта",
                "Создать",
                Visibility.Hidden);
        }

        protected bool CanExecuteProjectCreate(object parameter)
        {
            return true;
        }

        protected void OnExecuteProjectEdit(object parameter)
        {
            ShowDialogProjectManagerWindow(
                _projectService.EditProjectToDbAsync,
                "Изменение проекта",
                "Изменить",
                Visibility.Visible,
                SelectedTabItem);
        }

        protected bool CanExecuteProjectEdit(object parameter)
        {
            return SelectedTabItem != null;
        }

        protected void OnExecuteProjectRemove(object parameter)
        {
            ShowDialogProjectManagerWindow(
                _projectService.RemoveProjectToDbAsync,
                "Удаление проекта",
                "Удалить",
                Visibility.Hidden,
                SelectedTabItem);
        }

        protected bool CanExecuteProjectRemove(object parameter)
        {
            return SelectedTabItem != null;
        }

        private void ShowDialogProjectManagerWindow(
            Func<ProjectDataModel, Task> CreateOrUpdateOrDeleteAction,
            string windowTitle,
            string executeCutButtonContent,
            Visibility resetCutButtonVisibility,
            ProjectWpfModel? project = null)
        {
            project ??= new ProjectWpfModel();

            // Сперва обязательно надо создать модель, потом только окно.
            CreateProjectManagerWindowViewModel(project, CreateOrUpdateOrDeleteAction, executeCutButtonContent, resetCutButtonVisibility);
            CreateProjectManagerWindow(windowTitle);

            _projectManagerWindow!.ShowDialog();
        }

        private void CreateProjectManagerWindow(string windowTitle)
        {
            _projectManagerWindow = new ProjectManagerWindow()
            {
                Owner = Application.Current.MainWindow,
                Title = windowTitle,
                DataContext = _projectManagerWindowViewModel
            };

            _projectManagerWindow.Closed += OnDialogWindowClosed!;
        }

        private void CreateProjectManagerWindowViewModel(
            ProjectWpfModel project,
            Func<ProjectDataModel, Task> executeCudAction,
            string executeCudButtonContent,
            Visibility resetCutButtonVisibility)
        {
            _projectManagerWindowViewModel = new ProjectManagerWindowViewModel();
            _projectManagerWindowViewModel.ResetButtonVisibility = resetCutButtonVisibility;
            _projectManagerWindowViewModel
                .InitializeProjectManagerWindowViewModel(project, executeCudAction, executeCudButtonContent);
        }

        private void OnDialogWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnDialogWindowClosed!;
            _projectManagerWindow = null;
            _projectManagerWindowViewModel = null;
            SelectedTabItem = null;
        }
    }
}
