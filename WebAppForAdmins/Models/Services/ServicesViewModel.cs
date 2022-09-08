using WebModels;

namespace WebAppForAdmins.Models.Services
{
    public class ServicesViewModel
    {
        public IList<ServiceWebModel> Services { get; set; } = default!;
    }
}
