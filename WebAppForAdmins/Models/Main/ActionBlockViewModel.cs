using WebModels;

namespace WebAppForAdmins.Models.Main
{
    public class ActionBlockViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedActionId { get; set; }
        public List<MainPageActionModel> Actions { get; set; } = default!;
    }
}
