using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Repositories.Interfaces;
using WebAppForAdmins.Models.Account;
using Resources.Enums;

namespace WebAppForAdmins.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel() { Login = string.Empty, Password = string.Empty });
        }

        [HttpPost]
        public async Task<IActionResult> LoginPost(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Login), model);
            }

            var user = _userRepository.Login(model.Login, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("Password", "Неверный логин или пароль");
                return View(nameof(Login), model);
            }

            if (user.Role == null)
            {
                return RedirectToAction("Index", "Home");
            }

            await Authenticate(user.Login, user.Role.Name);
            return RedirectToAction("Index", "Applications");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel());
        }

        private async Task Authenticate(string login, string role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, role)
            };
            // создаем объект ClaimsIdentity
            var id = new ClaimsIdentity(
                claims,
                "ApplicationCookie",
                ClaimTypes.Name,
                ClaimTypes.Role);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
