using System.Windows.Media.Imaging;
using System;
using WpfAppForEmployees.WpfModels.Base;

namespace WpfAppForEmployees.WpfModels
{
    public class BlogWpfModel : BaseWpfModel
    {
        public string BlogTitle { get; set; } = default!;
        public string ShortBlogDescription { get; set; } = default!;
        public string LongBlogDescription { get; set; } = default!;
        public BitmapImage? BlogImageAsBitmap { get; set; }

        public DateTime PublicationDateAsDateTime { get; set; } = default!;
        public string PublicationDateAsString
        {
            get => PublicationDateAsDateTime.ToString("dd.MM.yyyy");
        }

        public bool IsPublishedAsBool { get; set; }
        public string IsPublishedAsString
        {
            get => IsPublishedAsBool ? "Вкл." : "Выкл.";
        }
    }
}
