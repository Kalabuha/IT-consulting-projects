using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class HeaderViewModel
    {
        public MenuModel UsedMenu { get; set; } = default!;
        public SloganModel RandomSlogan { get; set; } = default!;
    }
}
