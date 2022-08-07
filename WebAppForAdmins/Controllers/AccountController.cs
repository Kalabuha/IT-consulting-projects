using Microsoft.AspNetCore.Mvc;

namespace WebAppForAdmins.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _userRepository;

        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel() { Login = string.Empty, Password = string.Empty });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userRepository.Login(model.Login, model.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Логин или пароль неверный.");
                return View(model);
            }

            await Authenticate(user.Login, user.Role);
            return RedirectToAction("Index", "Home");
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

        private async Task Authenticate(string login, UserRole role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, role.ToString())
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
