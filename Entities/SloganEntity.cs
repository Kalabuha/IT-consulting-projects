using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    [Table("Header_slogans")]

    public class SloganEntity : BaseEntity
    {
        [Column("Slogans"), Required, MaxLength(24)]
        public string Slogan { get; set; } = default!;

        [Column("Slogan_used"), Required]
        public bool IsUsed { get; set; }
    }
}
