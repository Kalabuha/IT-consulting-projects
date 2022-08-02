using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resources.Entities.Base;

namespace Resources.Entities
{
    [Table("Services")]
    public class ServiceEntity : SiteObjectEntity
    {
        [Column("Service_description"), MaxLength(1500), Required]
        public string ServiceDescription { get; set; } = default!;
    }
}
