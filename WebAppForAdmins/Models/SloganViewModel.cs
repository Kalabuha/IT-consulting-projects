using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class SloganViewModel
    {
        public string DefaultSloganContent { get; set; } = default!;
        public List<SloganModel> Slogans { get; set; } = default!;
    }
}
