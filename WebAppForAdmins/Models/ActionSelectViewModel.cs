using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class ActionSelectViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedActionId { get; set; }
        public List<MainPageActionModel> Actions { get; set; } = default!;
    }
}
