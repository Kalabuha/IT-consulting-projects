using Resources.Models;

namespace WebAppForAdmins.Models
{
    public class PhraseSelectViewModel
    {
        public int CurrentPresetId { get; set; }
        public int SelectedPhraseId { get; set; }
        public IList<MainPagePhraseModel> Phrases { get; set; } = default!;
    }
}
