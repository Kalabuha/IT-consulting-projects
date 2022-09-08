using WebModels;

namespace WebAppForGuests.Models
{
    public class HeaderViewModel
    {
        public HeaderMenuWebModel Menu { get; set; } = default!;
        public HeaderSloganWebModel Slogan { get; set; } = default!;
    }
}
