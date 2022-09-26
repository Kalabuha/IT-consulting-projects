using DataModels.Base;

namespace DataModels
{
    public class ProjectDataModel : BaseDataModel
    {
        public string ProjectTitle { get; set; } = default!;
        public string ProjectDescription { get; set; } = default!;
        public string? LinkToCustomerSite { get; set; }
        public byte[] CustomerCompanyLogoAsByte { get; set; } = default!;
        public bool IsPublished { get; set; }
    }
}
