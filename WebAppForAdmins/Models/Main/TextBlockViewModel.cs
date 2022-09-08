using WebModels;

namespace WebAppForAdmins.Models.Main
{
    public class TextBlockViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedTextId { get; set; }
        public IList<MainPageTextWebModel> Texts { get; set; } = default!;
        public MainPageTextWebModel? CreatedText { get; set; }
    }
}
