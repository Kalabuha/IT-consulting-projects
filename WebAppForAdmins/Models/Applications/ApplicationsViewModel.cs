using WebModels;

namespace WebAppForAdmins.Models.Applications
{
    public class ApplicationsViewModel
    {
        public IList<ApplicationModel> Applications { get; set; } = default!;
    }
}
