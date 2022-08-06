using Microsoft.AspNetCore.Http;
using Resources.Models.Base;

namespace Resources.Models
{
    public class MainPageImageModel : BaseModel
    {
        public string ImageAsString { get; set; } = default!;
        public IFormFile? ImageAsFormFile { get; set; }

    }
}
