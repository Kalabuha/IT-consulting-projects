using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    [Table("Page_actions")]
    public class MainPageActionEntity : BaseEntity
    {
        [Column("Actions"), Required, MaxLength(60)]
        public string Action { get; set; } = default!;

        public ICollection<MainPagePresetEntity>? Presets { get; set; }
    }
}
