using WebModels;

namespace WebAppForGuests.Models
{
    public class MainPageViewModel
    {
        public string PageH1 { get; set; } = default!;

        public MainPageTextWebModel TextModel { get; set; } = default!;
        public MainPageImageWebModel? ImageModel { get; set; }
        public MainPageButtonWebModel? ButtonModel { get; set; }
        public MainPagePhraseWebModel? PhraseModel { get; set; }
        public MainPageActionWebModel ActionModel { get; set; } = default!;

        public ApplicationWebModel ApplicationModel { get; set; } = default!;
    }
}
