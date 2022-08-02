using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resources.Entities.Base
{
    public abstract class SiteObjectEntity : BaseEntity
    {
        [Column("Title"), MaxLength(150), Required]
        public string Title { get; set; } = default!;

        [Column("Is_published"), Required]
        public bool IsPublished { get; set; }
    }
}