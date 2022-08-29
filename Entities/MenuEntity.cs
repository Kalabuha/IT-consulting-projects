using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Base;

namespace Entities
{
    [Table("Menu_sets")]
    public class MenuEntity : PageEntity
    {
        [Column("Menu_items_main"), Required, MaxLength(12)]
        public string Main { get; set; } = default!;

        [Column("Menu_items_services"), Required, MaxLength(12)]
        public string Services { get; set; } = default!;

        [Column("Menu_items_projects"), Required, MaxLength(12)]
        public string Projects { get; set; } = default!;

        [Column("Menu_items_blogs"), Required, MaxLength(12)]
        public string Blogs { get; set; } = default!;

        [Column("Menu_items_contacts"), Required, MaxLength(12)]
        public string Contacts { get; set; } = default!;
    }
}
