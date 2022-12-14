using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    [Table("Page_phrases")]
    public class MainPagePhraseEntity : BaseEntity
    {
        [Column("Phrases"), Required, MaxLength(44)]
        public string Phrase { get; set; } = default!;

        public ICollection<MainPagePresetEntity>? Presets { get; set; }
    }
}
