using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YourNamespace.Models;

namespace YourNamespace.Controllers
{
    public class AccountController : Controller
    {
        // Статический список для хранения пользователей
        private static List<UserModel> Users = new List<UserModel>();

        // GET: Account/Register
        public ActionResult Register()
        {
            return View(Users); // Передаем текущий список пользователей в представление
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверка уникальности Email и Username
                if (Users.Any(u => u.Email.Equals(model.Email, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Email", "Электронная почта уже зарегистрирована");
                    return View(Users);
                }

                if (Users.Any(u => u.Username.Equals(model.Username, StringComparison.OrdinalIgnoreCase)))
                {
                    ModelState.AddModelError("Username", "Логин уже используется");
                    return View(Users);
                }

                // Хэширование пароля (опционально, для демонстрации)
                model.Password = HashPassword(model.Password);
                model.ConfirmPassword = null; // Удаляем подтверждение пароля

                // Добавление пользователя в список
                Users.Add(model);

                // Добавление сообщения об успешной регистрации
                TempData["SuccessMessage"] = "Регистрация успешна!";

                return RedirectToAction("Register");
            }

            // Если модель не валидна, возвращаем текущий список пользователей
            return View(Users);
        }

        // Метод для хэширования пароля (опционально)
        private string HashPassword(string password)
        {
            // Простой пример хэширования с использованием SHA256
            using (var sha = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(password);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
