using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DevScienceAdminUI.Models;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http.Headers;

namespace DevScienceAdminUI.Views.Projects
{
    [Route("/[controller]")]
    public class ProjectsController : Controller
    {
        private static readonly HttpClient client = new();

        //public async Task<IActionResult> IndexAsync()
        //{
        //    var response = await client.GetAsync("http://192.168.100.26:5002/Project/get-all");
        //    var responseBody = await response.Content.ReadAsStringAsync();

        //    var projects = JsonConvert.DeserializeObject<List<Project>>(responseBody);


        //    if (projects is null)
        //    {
        //        return NotFound();
        //    }

        //    return View(await GetProjectViewModels(projects));
        //}

        public async Task<IActionResult> IndexAsync()
        {
            return View(new List<ProjectViewModel>(){ new ProjectViewModel()
            {
                Description = "description",
                EmployeeId = new List<Employee>()
                {
                    new Employee() { Id = 1, FirstName = "FirstName", SecondName = "SecondName", LastName = "LastName", Technology = new List<Technology>()
                    {
                        Technology.Angular,
                        Technology.PHP
                    },
                        Telegram = "@nikitastud",
                    } },
                Id = 1,
                Name = "Microsoft",
                Technology = new List<Technology>()
                {
                    Technology.SQL,
                    Technology.Java
                }
            } }
            );
        }

        private async Task<List<ProjectViewModel>> GetProjectViewModels(List<Project>? projects)
        {
            if (projects is null)
            {
                return new List<ProjectViewModel>();
            }

            var list = new List<ProjectViewModel>();

            foreach (var project in projects)
            {
                var projectModel = new ProjectViewModel
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    Technology = project.Technology,
                    EmployeeId = new List<Employee>(),
                    RequestId = new List<Employee>()
                };
                if (project.EmployeeId != null)
                {
                    foreach (int employeeId in project.EmployeeId)
                    {
                        using (var request = new HttpRequestMessage(HttpMethod.Get, $"http://192.168.100.26:5002/Employee/get-by-id?id={employeeId}"))
                        {
                            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["accessToken"]);
                            var response = await client.SendAsync(request);

                            response.EnsureSuccessStatusCode();

                            var responseBody = await response.Content.ReadAsStringAsync();
                            var employee = JsonConvert.DeserializeObject<Employee>(responseBody);
                            if (employee is not null)
                            {
                                projectModel.EmployeeId.Add(employee);
                            }
                        }
                    }
                }
                if (project.RequestId != null)
                {
                    foreach (int requestId in project.RequestId)
                    {
                        using (var request = new HttpRequestMessage(HttpMethod.Get, $"http://192.168.100.26:5002/Employee/get-by-id?id={requestId}"))
                        {
                            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["accessToken"]);
                            var response = await client.SendAsync(request);

                            response.EnsureSuccessStatusCode();

                            var responseBody = await response.Content.ReadAsStringAsync();
                            var employee = JsonConvert.DeserializeObject<Employee>(responseBody);
                            if (employee is not null)
                            {
                                projectModel.RequestId.Add(employee);
                            }
                        }
                    }
                }

                list.Add(projectModel);
            }
            return list;
        }
    }
}
