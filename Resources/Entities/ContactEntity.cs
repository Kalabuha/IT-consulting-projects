using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resources.Entities.Base;

namespace Resources.Entities
{
    [Table("Contacts")]
    public class ContactEntity : PageEntity
    {
        [Column("Postcode"), Required]
        public int Postcode { get; set; }

        [Column("Address"), Required, MaxLength(150)]
        public string Address { get; set; } = default!;

        [Column("Phone"), Required, MaxLength(20)]
        public string Phone { get; set; } = default!;

        [Column("Fax"), MaxLength(20)]
        public string? Fax { get; set; }

        [Column("Map"), Required]
        public byte[] MapAsArray64 { get; set; } = default!;
    }
}
