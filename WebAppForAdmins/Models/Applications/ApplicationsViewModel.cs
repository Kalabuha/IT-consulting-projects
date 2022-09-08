using WebModels;

namespace WebAppForAdmins.Models.Applications
{
    public class ApplicationsViewModel
    {
        public IList<ApplicationWebModel> Applications { get; set; } = default!;
    }
}
