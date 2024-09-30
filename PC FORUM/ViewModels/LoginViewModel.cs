using System.ComponentModel.DataAnnotations;

namespace PC_FORUM.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Электронная почта")]
        [Required(ErrorMessage = "Нужно ввести электронную почту")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
    }
}
