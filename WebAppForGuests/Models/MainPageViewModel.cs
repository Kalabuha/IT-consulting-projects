using Resources.Models;

namespace WebAppForGuests.Models
{
    public class MainPageViewModel
    {
        public MainPageTextModel? Text { get; set; }
        public MainPageImageModel? Image { get; set; }
        public MainPageButtonModel? Button { get; set; }
        public MainPagePhraseModel? Phrase { get; set; }
        public MainPageActionModel? Action { get; set; }

        public ApplicationModel Application { get; set; } = default!;
    }
}
