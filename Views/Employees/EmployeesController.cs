using DevScienceAdminUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevScienceAdminUI.Views.Employees
{
    
    public class EmployeesController : Controller
    {
        private static readonly HttpClient client = new();

        [HttpGet]
        public async Task<IActionResult> Index(string telegram)
        {
            return View( 

                    new Employee() { Id = 1, FirstName = "FirstName", SecondName = "SecondName", LastName = "LastName", Technology = new List<Technology>()
                    {
                        Technology.Angular,
                        Technology.PHP
                    },
                        Telegram = telegram,
                    } 


            );
        }
        [HttpPost]
        public string Index(string name, int age) => $"{name}: {age}";

    }
}
