using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resources.Entities.Base
{
    public abstract class PageEntity : BaseEntity
    {
        [Column("Is_posted_on_the_page"), Required]
        public bool IsPublishedOnMainPage { get; set; }
    }
}
