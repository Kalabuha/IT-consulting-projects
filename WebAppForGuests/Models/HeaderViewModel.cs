using Resources.Models;

namespace WebAppForGuests.Models
{
    public class HeaderViewModel
    {
        public MenuModel Menu { get; set; } = default!;
        public SloganModel Slogan { get; set; } = default!;
    }
}
