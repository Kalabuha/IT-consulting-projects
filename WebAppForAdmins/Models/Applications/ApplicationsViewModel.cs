using Resources.Models;

namespace WebAppForAdmins.Models.Applications
{
    public class ApplicationsViewModel
    {
        public IList<ApplicationModel> Applications { get; set; } = default!;
    }
}
