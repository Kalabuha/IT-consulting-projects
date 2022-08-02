using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resources.Entities.Base;

namespace Resources.Entities
{
    [Table("Page_images")]
    public class MainPageImageEntity : BaseEntity
    {
        [Column("Image"), Required]
        public byte[] ImageAsArray64 { get; set; } = default!;

        public ICollection<MainPagePresetEntity>? Presets { get; set; }
    }
}
