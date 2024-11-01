using EntityModelMVC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EntityModelMVCWebApiApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:44376/api/employee";

        public async Task<List<EMPLOYEE>> GetEmployeAsync()
        {
            List<EMPLOYEE> employees = new List<EMPLOYEE>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);
                HttpResponseMessage response = await httpClient.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    employees = await response.Content.ReadAsAsync<List<EMPLOYEE>>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error fetching employee data.");
                }
            }
            return employees;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            List<EMPLOYEE> employee = await GetEmployeAsync();

            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(EMPLOYEE employee)
        {
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("", employee);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error adding employee data.");
                }
            }
            return View(employee);
        }


        public async Task<ActionResult> Edit(int id)
        {
            EMPLOYEE emp = null;
            using (var httpClient = new HttpClient())
            {
                var editApiUrl = $"{apiBaseUrl}/{id}";
                httpClient.BaseAddress = new Uri(editApiUrl);
                HttpResponseMessage response = await httpClient.GetAsync(id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    emp = await response.Content.ReadAsAsync<EMPLOYEE>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error fetching employee data.");
                }
            }
            return View(emp);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EMPLOYEE emp)
        {
            using (var httpClient = new HttpClient())
            {
                var editApiUrl = $"{apiBaseUrl}/{emp.EId}";
                httpClient.BaseAddress = new Uri(editApiUrl);
                HttpResponseMessage response = await httpClient.PutAsJsonAsync(editApiUrl, emp);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(editApiUrl, "Error updating employee data.");
                }
            }
            return View(emp);
        }



        public async Task<ActionResult> Delete(int id)
        {
            using(var httpClient = new HttpClient())
            {
                var deleteApiUrl = $"{apiBaseUrl}/{id}";
                httpClient.BaseAddress = new Uri(deleteApiUrl);
                HttpResponseMessage response = await httpClient.DeleteAsync(id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error deleting employee data.");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
