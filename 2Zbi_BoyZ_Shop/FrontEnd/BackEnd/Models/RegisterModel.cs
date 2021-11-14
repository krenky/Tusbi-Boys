using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class RegisterModel
    {
        public RegisterModel(string email, string password, string confirmPassword)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
            ConfirmPassword = confirmPassword ?? throw new ArgumentNullException(nameof(confirmPassword));
        }

        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

    }
}
