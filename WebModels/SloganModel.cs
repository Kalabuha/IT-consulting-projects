using System.ComponentModel.DataAnnotations;
using WebModels.Base;

namespace WebModels
{
    public class SloganModel : BaseModel
    {
        [Required(ErrorMessage = "Содержание слогана обязательно")]
        [StringLength(24, ErrorMessage = "Длина слогана не должна превышать 24 символа")]
        public string Slogan { get; set; } = default!;

        public bool IsUsed { get; set; }
    }
}
