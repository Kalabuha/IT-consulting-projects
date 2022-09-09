using System.Windows.Media.Imaging;
using WpfAppForEmployees.WpfModels.Base;

namespace WpfAppForEmployees.WpfModels
{
    public class ProjectWpfModel : BaseWpfModel
    {
        public string ProjectTitle { get; set; } = default!;
        public BitmapImage CustomerCompanyLogoAsBitmap { get; set; } = default!;
        public string? LinkToCustomerSite { get; set; }
        public string ProjectDescription { get; set; } = default!;

        public bool IsPublishedAsBool { get; set; }
        public string IsPublishedAsString
        {
            get => IsPublishedAsBool ? "Вкл." : "Выкл.";
        }
    }
}
