using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DevScienceAdminUI.Models;
using Newtonsoft.Json;

namespace DevScienceAdminUI.Views.Projects
{
    [Route("/[controller]")]
    public class ProjectsController : Controller
    {
        private static readonly HttpClient client = new();
        
        public async Task<IActionResult> IndexAsync()
        {
            var response = await client.GetAsync("http://192.168.100.26:5002/Project/get-all");
           var responseBody = await response.Content.ReadAsStringAsync();
            
            var projects = JsonConvert.DeserializeObject<List<Project>>(responseBody);

            if (projects is null)
            {
                return NotFound();
            }

            return View(projects);
        }
    }
}
