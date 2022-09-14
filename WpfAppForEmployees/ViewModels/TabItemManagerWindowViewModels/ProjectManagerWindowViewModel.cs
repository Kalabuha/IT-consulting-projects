﻿using System;
using System.Threading.Tasks;
using WpfAppForEmployees.ViewModels.TabItemManagerWindowViewModels.Base;
using WpfAppForEmployees.WpfModels;
using WpfAppForEmployees.Commands;
using WpfAppForEmployees.DataModelsWpfModelsMappers;
using DataModels;

namespace WpfAppForEmployees.ViewModels.TabItemManagerWindowViewModels
{
    public class ProjectManagerWindowViewModel : BaseManagerWindowViewModel<ProjectWpfModel, ProjectDataModel>
    {
        public ProjectManagerWindowViewModel()
        {
            ExecuteCudActionCommand = new ActionCommand(OnExecuteCudAction, CanExecuteCudAction);
            ResetCudActionCommand = new ActionCommand(OnResetCudAction, CanResetCudAction);
        }

        public void InitializeProjectManagerWindowViewModel(
            ProjectWpfModel project,
            Func<ProjectDataModel, Task> executeCudAction,
            string contentExecuteCudActionButton)
        {
            ManagerItem = project;
            ExecuteCudAction = executeCudAction;
            ContentExecuteCudActionButton = contentExecuteCudActionButton;
        }

        private async void OnExecuteCudAction(object parameter)
        {
            if (ManagerItem != null && ExecuteCudAction != null)
            {
                var data = ManagerItem.ProjectWpfModelToDataModel();
                await ExecuteCudAction.Invoke(data);
            }

            //CloseTabItemManagerWindow(parameter);
        }

        private bool CanExecuteCudAction(object parameter)
        {
            return true;
        }

        private void OnResetCudAction(object parameter)
        {
            //CloseTabItemManagerWindow(parameter);
            var t = 5;
        }

        private bool CanResetCudAction(object parameter)
        {
            return true;
        }
    }
}
