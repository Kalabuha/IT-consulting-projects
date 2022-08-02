using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class TextSelectViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedTextId { get; set; }
        public IList<MainPageTextModel> Texts { get; set; } = default!;
    }
}
