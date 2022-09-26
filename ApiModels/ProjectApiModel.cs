using ApiModels.Base;

namespace ApiModels
{
    public class ProjectApiModel : BaseApiModel
    {
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public string? LinkToCustomerSite { get; set; }
        public byte[]? CustomerCompanyLogoAsByte { get; set; }
        public bool? IsPublished { get; set; }
    }
}
