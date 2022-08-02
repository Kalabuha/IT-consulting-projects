using Resources.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Resources.Models
{
    public class MenuModel : BaseModel
    {
        [Required(ErrorMessage = "Содержание пункта меню обязательно")]
        [StringLength(12, ErrorMessage = "Длина пункта меню не должна превышать 12 символов")]
        public string Main { get; set; } = default!;

        [Required(ErrorMessage = "Содержание пункта меню обязательно")]
        [StringLength(12, ErrorMessage = "Длина пункта меню не должна превышать 12 символов")]
        public string Services { get; set; } = default!;

        [Required(ErrorMessage = "Содержание пункта меню обязательно")]
        [StringLength(12, ErrorMessage = "Длина пункта меню не должна превышать 12 символов")]
        public string Projects { get; set; } = default!;

        [Required(ErrorMessage = "Содержание пункта меню обязательно")]
        [StringLength(12, ErrorMessage = "Длина пункта меню не должна превышать 12 символов")]
        public string Blogs { get; set; } = default!;

        [Required(ErrorMessage = "Содержание пункта меню обязательно")]
        [StringLength(12, ErrorMessage = "Длина пункта меню не должна превышать 12 символов")]
        public string Contacts { get; set; } = default!;

        public bool IsPublished { get; set; }
    }
}
