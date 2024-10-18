using DataLibEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationApiMvcDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:44353/api/employee";

        private async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> employees = new List<Employee>();
            using (var httpClient = new HttpClient())
            {
                // Make the API call
                httpClient.BaseAddress = new Uri(apiBaseUrl);
                HttpResponseMessage response = await httpClient.GetAsync("Employee");

                // Ensure the call was successful
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response content to List<Employee>
                    employees = await response.Content.ReadAsAsync<List<Employee>>();
                }
                else
                {
                    // Handle any error response
                    ModelState.AddModelError(string.Empty, "Error fetching employee data.");
                }
            }
            return employees;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            // Fetch employees from the API
            List<Employee> employees = await GetEmployeesAsync();

            // Pass the employees data to the view
            return View(employees);
        }
    }
}
