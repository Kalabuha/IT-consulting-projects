﻿using Microsoft.AspNetCore.Http;
using Resources.Models.Base;
using Resources.Validations;
using System.ComponentModel.DataAnnotations;

namespace Resources.Models
{
    public class ContactModel : BaseModel
    {
        [Range(100000, 999999, ErrorMessage = "Индекс должен состоять из 6 цифр")]
        [Required(ErrorMessage = "Индекс обязателен")]
        public int Postcode { get; set; }

        [Required(ErrorMessage = "Адрес обязателен")]
        [StringLength(150, ErrorMessage = "Длина адреса не должна превышать 150 символов")]
        public string Address { get; set; } = default!;

        [Required(ErrorMessage = "Телефонный номер обязателен")]
        [StringLength(20, ErrorMessage = "Длина телефонного номера не должна превышать 20 символов")]
        [PhoneNumber]
        public string Phone { get; set; } = default!;

        [StringLength(20, ErrorMessage = "Длина номера факса не должна превышать 20 символов")]
        [PhoneNumber(ErrorMessage = "Некорретный номер факса.")]
        public string? Fax { get; set; }

        public IFormFile? MapAsFormFile { get; set; }

        public string? MapAsString { get; set; }

        public bool IsPublished { get; set; }
    }
}
