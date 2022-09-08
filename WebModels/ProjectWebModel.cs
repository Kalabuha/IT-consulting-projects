using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WebModels.Base;

namespace WebModels
{
    public class ProjectWebModel : BaseWebModel //, IValidatableObject
    {
        [Required(ErrorMessage = "Заголовок проекта является обязательным")]
        [StringLength(150, ErrorMessage = "Длина заголовка не должна превышать 150 символов")]
        public string ProjectTitle { get; set; } = default!;

        [Required(ErrorMessage = "Описание является обязательным")]
        [StringLength(5000, ErrorMessage = "Слишком длинное описание")]
        public string ProjectDescription { get; set; } = default!;

        public IFormFile? CustomerCompanyLogoAsFormFile { get; set; }
        public string? CustomerCompanyLogoAsDataImage { get; set; }

        [StringLength(300, ErrorMessage = "Слишком длинная ссылка")]
        public string? LinkToCustomerSite { get; set; }

        public bool IsPublished { get; set; }
        


        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (string.IsNullOrEmpty(ProjectTitle))
        //        yield return new ValidationResult("Заголовок проекта является обязательным", 
        //            new[] { nameof(ProjectTitle) });

        //    if(IsPublished && ProjectDescription == null)
        //        yield return new ValidationResult("Для опубликованного проекта описание является обязательным", 
        //            new[] { nameof(ProjectDescription) });
        //}
    }
}
