using DevScienceAdminUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace DevScienceAdminUI.Views.Employees
{
    
    public class EmployeesController : Controller
    {
        private static readonly HttpClient client = new();


        [HttpGet]
        public async Task<IActionResult> Index(string telegram)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://192.168.100.26:5002/get-by-telegram?telegram={telegram}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["accessToken"]);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();


            var employee = JsonConvert.DeserializeObject<Employee>(responseBody);
            if (employee is null)
            {
                return NotFound();
            }
            return View(employee);
        }



        [HttpPost]
        public string Index(string name, int age) => $"{name}: {age}";

    }
}
