using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using WebModels.Base;

namespace WebModels
{
    public class BlogWebModel : BaseWebModel
    {
        [Required(ErrorMessage = "Заголовок блога является обязательным")]
        [StringLength(150, ErrorMessage = "Длина заголовка не должна превышать 150 символов")]
        public string BlogTitle { get; set; } = default!;

        [Required(ErrorMessage = "Начальное описание блога является обязательным")]
        [StringLength(500, ErrorMessage = "Длина заголовка не должна превышать 150 символов")]
        public string ShortBlogDescription { get; set; } = default!;

        [Required(ErrorMessage = "Основное описание блога является обязательным")]
        [StringLength(6000, ErrorMessage = "Длина заголовка не должна превышать 6000 символов")]
        public string LongBlogDescription { get; set; } = default!;

        public IFormFile? BlogImageAsFormFile { get; set; }
        public string? BlogImageAsString { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool IsPublished { get; set; }

        public bool IsRemoveImage { get; set; }
    }
}
