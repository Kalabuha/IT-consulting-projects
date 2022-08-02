﻿using Microsoft.AspNetCore.Http;
using Resources.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Resources.Models
{
    public class ProjectModel : BaseModel //, IValidatableObject
    {
        [Required(ErrorMessage = "Заголовок проекта является обязательным")]
        [StringLength(150, ErrorMessage = "Длина заголовка не должна превышать 150 символов")]
        public string ProjectTitle { get; set; } = default!;

        [Required(ErrorMessage = "Описание является обязательным")]
        [StringLength(5000, ErrorMessage = "Слишком длинное описание")]
        public string ProjectDescription { get; set; } = default!;

        public IFormFile? CustomerCompanyLogoAsFormFile { get; set; }
        public string? CustomerCompanyLogoAsDataImage { get; set; }

        public string? LinkToCustomerSite { get; set; } = default!;

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
