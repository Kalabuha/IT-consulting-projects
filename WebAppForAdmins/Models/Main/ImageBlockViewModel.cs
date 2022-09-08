using WebModels;

namespace WebAppForAdmins.Models.Main
{
    public class ImageBlockViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedImageId { get; set; }
        public int SelectedPhraseId { get; set; }
        public int SelectedButtonId { get; set; }
        public IList<MainPageImageWebModel> Images { get; set; } = default!;
        public IList<MainPagePhraseWebModel> Phrases { get; set; } = default!;
        public IList<MainPageButtonWebModel> Buttons { get; set; } = default!;

        public static ImageBlockViewModel CreateEmptyImageBlockViewModel()
        {
            var emptyImageBlockViewModel = new ImageBlockViewModel()
            {
                CurrentPresetId = 0,
                SelectedImageId = 0,
                SelectedPhraseId = 0,
                SelectedButtonId = 0,
                Images = new List<MainPageImageWebModel>(),
                Phrases = new List<MainPagePhraseWebModel>(),
                Buttons = new List<MainPageButtonWebModel>()
            };

            return emptyImageBlockViewModel;
        }
    }
}
