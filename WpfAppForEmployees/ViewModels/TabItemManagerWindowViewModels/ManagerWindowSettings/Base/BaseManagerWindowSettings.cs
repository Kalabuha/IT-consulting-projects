using System;
using System.Windows;
using System.Threading.Tasks;
using DataModels.Base;

namespace WpfAppForEmployees.ViewModels.TabItemManagerWindowViewModels.ManagerWindowSettings.Base
{
    public abstract class BaseManagerWindowSettings<TDataModel>
        where TDataModel : BaseDataModel
    {
        public string WindowTitle { get; set; } = default!;

        public Func<TDataModel, Task>? ExecuteCudAction;
        public string ExecuteCudButtonContent { get; set; } = default!;
        public Visibility ResetCudButtonVisibility { get; set; }
        public bool IsEditingEnable { get; set; } = true;
    }
}
