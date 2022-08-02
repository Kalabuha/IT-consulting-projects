using Microsoft.AspNetCore.Mvc;

namespace WebAppForAdmins.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
