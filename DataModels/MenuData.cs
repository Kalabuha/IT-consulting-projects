using DataModels.Base;

namespace DataModels
{
    public class MenuData : BaseData
    {
        public string Main { get; set; } = default!;
        public string Services { get; set; } = default!;
        public string Projects { get; set; } = default!;
        public string Blogs { get; set; } = default!;
        public string Contacts { get; set; } = default!;
        public bool IsPublished { get; set; }
    }
}
