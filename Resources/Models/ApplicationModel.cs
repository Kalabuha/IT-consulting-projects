using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Resources.Models.Base;
using Resources.Enums;

namespace Resources.Models
{
    public class ApplicationModel : BaseModel
    {
        public int Number { get; set; }

        [Required(ErrorMessage = "Имя является обязательным")]
        [StringLength(60, ErrorMessage = "Длина имени не должна превышать 60 символов")]
        public string GuestName { get; set; } = default!;

        [Required(ErrorMessage = "Адрес почты является обязательным")]
        [StringLength(100, ErrorMessage = "Длина адреса почты не должна превышать 100 символов")]
        public string GuestEmail { get; set; } = default!;

        [Required(ErrorMessage = "Заголовок проекта является обязательным")]
        [StringLength(4000, ErrorMessage = "Длина текста не должна превышать 4000 символов")]
        public string GuestApplicationText { get; set; } = default!;

        public DateTime DateReceiptApplication { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
