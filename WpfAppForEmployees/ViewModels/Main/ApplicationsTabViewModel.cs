using WpfAppForEmployees.ViewModels.Base;
using WpfAppForEmployees.ViewModels.Main.Base;
using Resources.Datas;
using System.Windows.Media.Imaging;

namespace WpfAppForEmployees.ViewModels.Main
{
    public class ApplicationsTabViewModel : BaseTabViewModel<ApplicationData>
    {
        public string Applications { get; set; } = "Вкладка - заявки";

        public void Metod()
        {
            var t = TabDataCollection;
        }
    }
}
