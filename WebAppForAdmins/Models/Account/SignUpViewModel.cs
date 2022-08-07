using System.ComponentModel.DataAnnotations;

namespace WebAppForAdmins.Models.Account
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [StringLength(60, ErrorMessage = "Длина логина не должна превышать 60 символов")]
        public string Login { get; set; } = default!;


        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(30, ErrorMessage = "Длина пароля не должна превышать 30 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;


        [Required(ErrorMessage = "Повторите пароль")]
        [StringLength(30, ErrorMessage = "Длина пароля не должна превышать 30 символов")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; } = default!;
    }
}
