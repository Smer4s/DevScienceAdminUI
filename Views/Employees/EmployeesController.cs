using Microsoft.AspNetCore.Mvc;

namespace DevScienceAdminUI.Views.Employees
{
    [Route("/[controller]")]
    public class EmployeesController : Controller
    {
        private static readonly HttpClient client = new();

        public IActionResult Index()
        {
            return View();
        }
    }
}
