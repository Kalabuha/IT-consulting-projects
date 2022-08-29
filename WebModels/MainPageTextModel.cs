using WebModels.Base;
using System.ComponentModel.DataAnnotations;

namespace WebModels
{
    public class MainPageTextModel : BaseModel
    {
        [Required(ErrorMessage = "Содержание текста является обязательным")]
        [StringLength(4000, ErrorMessage = "Длина текста не должна превышать 4000 символов")]
        public string Text { get; set; } = default!;
    }
}
