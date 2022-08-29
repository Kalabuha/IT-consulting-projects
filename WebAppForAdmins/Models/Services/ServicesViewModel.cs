using WebModels;

namespace WebAppForAdmins.Models.Services
{
    public class ServicesViewModel
    {
        public IList<ServiceModel> Services { get; set; } = default!;
    }
}
