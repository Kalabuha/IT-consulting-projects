using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class MainViewModel
    {
        public MainPagePresetModel? SelectedPreset { get; set; }
        public List<MainPagePresetModel> Presets { get; set; } = default!;
    }
}
