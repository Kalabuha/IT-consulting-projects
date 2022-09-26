using ApiModels.Base;

namespace ApiModels
{
    public class BlogApiModel : BaseApiModel
    {
        public string? BlogTitle { get; set; }
        public string? ShortBlogDescription { get; set; }
        public string? LongBlogDescription { get; set; }
        public byte[]? BlogImageAsByte { get; set; }
        public bool? IsPublished { get; set; }
    }
}
