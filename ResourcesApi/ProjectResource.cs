using ResourcesApi.Base;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ResourcesApi
{
    public class ProjectResource : BaseResource
    {
        public string ProjectTitle { get; set; } = default!;

        public BitmapImage? CustomerCompanyLogoAsString { get; set; }

        public string? LinkToCustomerSite { get; set; }

        public string ProjectDescription { get; set; } = default!;

        public bool IsPublished { get; set; }
    }
}
