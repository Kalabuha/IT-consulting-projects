using System.ComponentModel;
using System.Windows.Media.Imaging;
using WpfAppForEmployees.WpfModels.Base;

namespace WpfAppForEmployees.WpfModels
{
    public class ProjectWpfModel : BaseWpfModel, IDataErrorInfo
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

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ProjectTitle):
                        if (CheckStringOnNullOrEmptyOrWhiteSpace(ProjectTitle)) return "Заголовок проекта обязателен";
                        if (CheckLengthString(ProjectTitle, 150)) return "Заголовок не должен превышать 150 символов";
                        break;

                    case nameof(LinkToCustomerSite):
                        if (!CheckStringOnNullOrEmptyOrWhiteSpace(LinkToCustomerSite))
                        {
                            if (CheckLengthString(LinkToCustomerSite!, 300))
                            {
                                return "Ссылка не должна превышать 300 символов";
                            }
                        }
                        break;

                    case nameof(ProjectDescription):
                        if (CheckStringOnNullOrEmptyOrWhiteSpace(ProjectDescription)) return "Описание проекта обязательно";
                        if (CheckLengthString(ProjectDescription, 5000)) return "Описание не должно превышать 5000 символов";
                        break;
                }

                return string.Empty;
            } 
        }
        public string Error => throw new System.NotImplementedException();

        private static bool CheckStringOnNullOrEmptyOrWhiteSpace(string? property)
        {
            return string.IsNullOrEmpty(property) || string.IsNullOrWhiteSpace(property);
        }

        private static bool CheckLengthString(string property, int length)
        {
            return property.Length > length;
        }
    }
}
