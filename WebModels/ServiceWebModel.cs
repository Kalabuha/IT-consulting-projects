using WebModels.Base;
using System.ComponentModel.DataAnnotations;

namespace WebModels
{
    public class ServiceWebModel : BaseWebModel
    {
        [Required(ErrorMessage = "Название услуги является обязательным")]
        [StringLength(150, ErrorMessage = "Длина названия услуги не должна превышать 150 символов")]
        public string ServiceName { get; set; } = default!;

        [Required(ErrorMessage = "Описание услуги является обязательным")]
        [StringLength(1500, ErrorMessage = "Длина описания услуги не должна превышать 1500 символов")]
        public string ServiceDescription { get; set; } = default!;

        public bool IsPublished { get; set; }
    }
}
