using WebModels;

namespace WebAppForAdmins.Models.Main
{
    public class TextBlockViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedTextId { get; set; }
        public IList<MainPageTextModel> Texts { get; set; } = default!;
        public MainPageTextModel? CreatedText { get; set; }
    }
}
