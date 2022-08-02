using Microsoft.AspNetCore.Mvc;

namespace WebAppForAdmins.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
