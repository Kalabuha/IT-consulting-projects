using WebModels;

namespace WebAppForAdmins.Models.Header
{
    public class HeaderViewModel
    {
        public MenuModel UsedMenu { get; set; } = default!;
        public SloganModel RandomSlogan { get; set; } = default!;
    }
}
