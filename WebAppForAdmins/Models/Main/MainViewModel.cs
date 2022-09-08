using WebModels;

namespace WebAppForAdmins.Models.Main
{
    public class MainViewModel
    {
        public MainPagePresetWebModel? SelectedPreset { get; set; }
        public List<MainPagePresetWebModel> Presets { get; set; } = default!;
    }
}
