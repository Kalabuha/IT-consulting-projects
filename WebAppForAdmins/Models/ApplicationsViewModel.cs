using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class ApplicationsViewModel
    {
        public IList<ApplicationModel> Applications { get; set; } = default!;
    }
}
