using System.ComponentModel.DataAnnotations;

namespace PC_FORUM.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Обязательна электронная почта")]
        public string Email { get; set; }
        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Имя пользователя обязательно")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароль не совпадает")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
