using DataModels.Base;

namespace DataModels
{
    public class ProjectData : BaseData
    {
        public int Id { get; set; }

        public string ProjectTitle { get; set; } = default!;

        public string? CustomerCompanyLogoAsString { get; set; }

        public string? LinkToCustomerSite { get; set; }

        public string ProjectDescription { get; set; } = default!;

        public bool IsPublished { get; set; }
    }
}
