using WebModels;

namespace WebAppForAdmins.Models.Header
{
    public class HeaderViewModel
    {
        public HeaderMenuWebModel UsedMenu { get; set; } = default!;
        public HeaderSloganWebModel RandomSlogan { get; set; } = default!;
    }
}
