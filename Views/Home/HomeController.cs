using Microsoft.AspNetCore.Mvc;

namespace DevScienceAdminUI.Views.Home
{
    [Route("/[controller]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["message"] = "home";
            return View();
        }
    }
}
