using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    [Table("Page_buttons")]
    public class MainPageButtonEntity : BaseEntity
    {
        [Column("Buttons"), Required, MaxLength(16)]
        public string Button { get; set; } = default!;

        public ICollection<MainPagePresetEntity>? Presets { get; set; }
    }
}
