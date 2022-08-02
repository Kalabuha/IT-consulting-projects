using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Resources.Entities.Base;

namespace Resources.Entities
{
    [Table("Projects")]
    public class ProjectEntity : SiteObjectEntity
    {
        [Column("Customer_company_logo"), Required]
        public byte[] CustomerCompanyLogoAsArray64 { get; set; } = default!;

        [Column("Link_to_customer_site"), MaxLength(300)]
        public string? LinkToCustomerSite { get; set; }

        [Column("Project_article"), MaxLength(5000), Required]
        public string ProjectDescription { get; set; } = default!;
    }
}
