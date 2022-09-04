using DataModels.Base;

namespace DataModels
{
    public class BlogData : BaseData
    {
        public string BlogTitle { get; set; } = default!;
        public string ShortBlogDescription { get; set; } = default!;
        public string LongBlogDescription { get; set; } = default!;

        public string? BlogImageAsString { get; set; }

        public DateTime PublicationDate { get; set; }
        public bool IsPublished { get; set; }
    }
}
