using WebModels;

namespace WebAppForAdmins.Models.Header
{
    public class SloganViewModel
    {
        public string DefaultSloganContent { get; set; } = default!;
        public List<HeaderSloganWebModel> Slogans { get; set; } = default!;
    }
}
