using System;
using System.ComponentModel.DataAnnotations;

namespace YourNamespace.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        [StringLength(50, ErrorMessage = "Имя не может быть длиннее 50 символов")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        [StringLength(50, ErrorMessage = "Фамилия не может быть длиннее 50 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Дата рождения обязательна")]
        [DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Электронная почта обязательна")]
        [EmailAddress(ErrorMessage = "Неверный формат электронной почты")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Логин обязателен")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Логин должен содержать от 5 до 50 символов")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Пароль должен содержать как минимум 6 символов")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
