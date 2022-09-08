using Microsoft.AspNetCore.Http;
using WebModels.Base;

namespace WebModels
{
    public class MainPageImageWebModel : BaseWebModel
    {
        public string ImageAsString { get; set; } = default!;
        public IFormFile? ImageAsFormFile { get; set; }
    }
}
