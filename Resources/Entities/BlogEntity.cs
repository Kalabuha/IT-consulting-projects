using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resources.Entities.Base;

namespace Resources.Entities
{
    [Table("Blogs")]
    public class BlogEntity : SiteObjectEntity
    {
        [Column("Creation_date"), Required]
        public DateTime PublicationDate { get; set; }

        [Column("Short_description"), MaxLength(500), Required]
        public string ShortBlogDescription { get; set; } = default!;

        [Column("Long_description"), MaxLength(6000), Required]
        public string LongBlogDescription { get; set; } = default!;

        [Column("Blog_image")]
        public byte[]? BlogImageAsArray64 { get; set; }
    }
}
