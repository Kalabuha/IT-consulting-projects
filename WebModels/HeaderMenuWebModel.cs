using WebModels.Base;
using System.ComponentModel.DataAnnotations;

namespace WebModels
{
    public class HeaderMenuWebModel : BaseWebModel
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
