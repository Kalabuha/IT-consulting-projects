using DataModels.Base;

namespace DataModels
{
    public class BlogDataModel : BaseDataModel
    {
        public string BlogTitle { get; set; } = default!;
        public string ShortBlogDescription { get; set; } = default!;
        public string LongBlogDescription { get; set; } = default!;

        public byte[]? BlogImageAsByte { get; set; }

        public DateTime PublicationDate { get; set; }
        public bool IsPublished { get; set; }
    }
}
