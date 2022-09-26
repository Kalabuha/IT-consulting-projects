using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppForEmployees.Commands;
using WpfAppForEmployees.DataModelsWpfModelsMappers;
using WpfAppForEmployees.ViewModels.TabItemManagerWindowViewModels;
using WpfAppForEmployees.ViewModels.TabItemManagerWindowViewModels.ManagerWindowSettings;
using WpfAppForEmployees.ViewModels.TabViewModels.Base;
using WpfAppForEmployees.Views.TabItemManagerWindows;
using WpfAppForEmployees.WpfModels;
using ServiceInterfaces;

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

            CreateTabItemCommand = new ActionCommand(OnExecuteCreateProject, CanExecuteCreateProject);
            EditTabItemCommand = new ActionCommand(OnExecuteEditProject, CanExecuteEditProject);
            RemoveTabItemCommand = new ActionCommand(OnExecuteRemoveProject, CanExecuteRemoveProject);
        }

        public async Task LoadData()
        {
            var projects = (await _projectService.GetAllProjectDatasAsync())
                .Select(p => p.ProjectDataModelToWpfModel());

            TabItems = new ObservableCollection<ProjectWpfModel>(projects);
        }

        protected void OnExecuteCreateProject(object parameter)
        {
            var settings = new ProjectManagerWindowSettings
            {
                WindowTitle = "Создание проекта",
                ExecuteCudAction = _projectService.AddProjectToDbAsync,
                ExecuteCudButtonContent = "Создать",
                ResetCudButtonVisibility = Visibility.Hidden,
                IsEditingEnable = true
            };

            ShowDialogProjectManagerWindow(settings);
        }

        protected bool CanExecuteCreateProject(object parameter)
        {
            return true;
        }

        protected void OnExecuteEditProject(object parameter)
        {
            var settings = new ProjectManagerWindowSettings
            {
                WindowTitle = "Изменение проекта",
                ExecuteCudAction = _projectService.EditProjectToDbAsync,
                ExecuteCudButtonContent = "Изменить",
                ResetCudButtonVisibility = Visibility.Visible,
                IsEditingEnable = true
            };

            ShowDialogProjectManagerWindow(settings, SelectedTabItem);
        }

        protected bool CanExecuteEditProject(object parameter)
        {
            return SelectedTabItem != null;
        }

        protected void OnExecuteRemoveProject(object parameter)
        {
            var settings = new ProjectManagerWindowSettings
            {
                WindowTitle = "Удаление проекта",
                ExecuteCudAction = _projectService.RemoveProjectToDbAsync,
                ExecuteCudButtonContent = "Удалить",
                ResetCudButtonVisibility = Visibility.Hidden,
                IsEditingEnable = false
            };

            ShowDialogProjectManagerWindow(settings, SelectedTabItem);
        }

        protected bool CanExecuteRemoveProject(object parameter)
        {
            return SelectedTabItem != null;
        }

        private void ShowDialogProjectManagerWindow(ProjectManagerWindowSettings settings, ProjectWpfModel? project = null)
        {
            project ??= new ProjectWpfModel();

            // Сперва обязательно надо создать модель, потом только окно.
            CreateProjectManagerWindowViewModel(settings, project);
            CreateProjectManagerWindow();

            _projectManagerWindow!.ShowDialog();
        }

        private void CreateProjectManagerWindow()
        {
            _projectManagerWindow = new ProjectManagerWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = _projectManagerWindowViewModel
            };

            _projectManagerWindow.Closed += OnDialogWindowClosed!;
        }

        private void CreateProjectManagerWindowViewModel(ProjectManagerWindowSettings settings, ProjectWpfModel project)
        {
            // ProjectManagerWindowViewModel - ему важно иметь конструктор без параметров.
            _projectManagerWindowViewModel = new ProjectManagerWindowViewModel();
            _projectManagerWindowViewModel.InitializeViewModel(settings, project);
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
