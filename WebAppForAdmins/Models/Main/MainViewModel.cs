using WebModels;

namespace WebAppForAdmins.Models.Main
{
    public class MainViewModel
    {
        public MainPagePresetModel? SelectedPreset { get; set; }
        public List<MainPagePresetModel> Presets { get; set; } = default!;
    }
}
