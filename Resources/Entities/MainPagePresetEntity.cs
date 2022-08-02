using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resources.Entities.Base;

namespace Resources.Entities
{
    [Table("Main_page_presets")]
    public class MainPagePresetEntity : PageEntity
    {
        [Column("Preset_name"), Required, MaxLength(40)]
        public string PresetName { get; set; } = default!;

        [Column("Text_id")]
        public int? TextId { get; set; }
        public MainPageTextEntity? Text { get; set; }

        [Column("Image_id")]
        public int? ImageId { get; set; }
        public MainPageImageEntity? Image { get; set; }

        [Column("Phrase_id")]
        public int? PhraseId { get; set; }
        public MainPagePhraseEntity? Phrase { get; set; }

        [Column("Button_id")]
        public int? ButtonId { get; set; }
        public MainPageButtonEntity? Button { get; set; }

        [Column("Action_id")]
        public int? ActionId { get; set; }
        public MainPageActionEntity? Action { get; set; }
    }
}
