using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    [Table("Services")]
    public class ServiceEntity : SiteObjectEntity
    {
        [Column("Service_description"), MaxLength(1500), Required]
        public string ServiceDescription { get; set; } = default!;
    }
}
