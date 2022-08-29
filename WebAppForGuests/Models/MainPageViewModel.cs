using WebModels;

namespace WebAppForGuests.Models
{
    public class MainPageViewModel
    {
        public string PageH1 { get; set; } = default!;

        public MainPageTextModel TextModel { get; set; } = default!;
        public MainPageImageModel? ImageModel { get; set; }
        public MainPageButtonModel? ButtonModel { get; set; }
        public MainPagePhraseModel? PhraseModel { get; set; }
        public MainPageActionModel ActionModel { get; set; } = default!;

        public ApplicationModel ApplicationModel { get; set; } = default!;
    }
}
