using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using DevScienceAdminUI.Models;
using Microsoft.AspNetCore.Http;
using NuGet.Protocol.Plugins;

namespace DevScienceAdminUI.Views.Auth
{
    [Route("/[controller]")]
    public class AuthController : Controller
    {
        private static readonly HttpClient client = new();
        [HttpGet]
        public IActionResult Index() => View();
        [HttpPost]
        public async Task<IActionResult> Index(string username, string password)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>());
            var response = await client.PostAsync($"http://192.168.100.26:5002/Auth/login?login={username}&password={password}", content);


            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(await response.Content.ReadAsStringAsync());

            if (dict != null)
            {
                Response.Cookies.Append("accessToken", dict["accessToken"]);
                Response.Cookies.Append("refreshToken", dict["refreshToken"]);
                return Redirect("/Projects");
            }
            return View();
        }
    }
}
