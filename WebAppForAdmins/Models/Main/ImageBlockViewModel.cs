using Resources.Models;

namespace WebAppForAdmins.Models.Main
{
    public class ImageBlockViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedImageId { get; set; }
        public int SelectedPhraseId { get; set; }
        public int SelectedButtonId { get; set; }
        public IList<MainPageImageModel> Images { get; set; } = default!;
        public IList<MainPagePhraseModel> Phrases { get; set; } = default!;
        public IList<MainPageButtonModel> Buttons { get; set; } = default!;

        public static ImageBlockViewModel CreateEmptyImageBlockViewModel()
        {
            var emptyImageBlockViewModel = new ImageBlockViewModel()
            {
                CurrentPresetId = 0,
                SelectedImageId = 0,
                SelectedPhraseId = 0,
                SelectedButtonId = 0,
                Images = new List<MainPageImageModel>(),
                Phrases = new List<MainPagePhraseModel>(),
                Buttons = new List<MainPageButtonModel>()
            };

            return emptyImageBlockViewModel;
        }
    }
}
