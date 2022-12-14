using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    [Table("Page_texts")]
    public class MainPageTextEntity : BaseEntity
    {
        [Column("Text"), MaxLength(4000), Required]
        public string Text { get; set; } = default!;

        public ICollection<MainPagePresetEntity>? Presets { get; set; }
    }
}
