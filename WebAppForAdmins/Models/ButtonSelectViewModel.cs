using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class ButtonSelectViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedButtonId { get; set; }
        public IList<MainPageButtonModel> Buttons { get; set; } = default!;
    }
}
