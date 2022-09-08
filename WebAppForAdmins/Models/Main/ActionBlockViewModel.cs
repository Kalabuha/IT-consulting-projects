using WebModels;

namespace WebAppForAdmins.Models.Main
{
    public class ActionBlockViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedActionId { get; set; }
        public List<MainPageActionWebModel> Actions { get; set; } = default!;
    }
}
