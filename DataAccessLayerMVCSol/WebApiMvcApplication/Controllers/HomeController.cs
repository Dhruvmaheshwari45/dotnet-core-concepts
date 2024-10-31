using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApiMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apiBaseUrl = "https://localhost:44391/api/employee";

        public async Task<List<EmpOrm>> GetEmpOrmsAsync()
        {
            List<EmpOrm> list = new List<EmpOrm>();
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);
                HttpResponseMessage response = await httpClient.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    list = await response.Content.ReadAsAsync<List<EmpOrm>>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error fetching employee data.");
                }
            }
            return list;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";
            List<EmpOrm> employees = await GetEmpOrmsAsync();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmpOrm emp)
        {
            using(var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apiBaseUrl);
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("", emp);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error adding employee data.");
                }
            }
            return View(emp);
        }

        public async Task<ActionResult> Edit(int id)
        {
            EmpOrm emp = null;
            using(var httpClient = new HttpClient())
            {
                var editApiUrl = $"{apiBaseUrl}/{id}";
                httpClient.BaseAddress = new Uri(editApiUrl);
                HttpResponseMessage response = await httpClient.GetAsync(id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    emp = await response.Content.ReadAsAsync<EmpOrm>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error fetching employee data.");
                }
            }
            return View(emp);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EmpOrm emp)
        {
            using(var httpClient = new HttpClient())
            {
                var editApiUrl = $"{apiBaseUrl}/{emp.EmpId}";
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
            //var deleteApiUrl = $"{apiBaseUrl}/{id}";
            //var deleteUrl = apiBaseUrl + "/" + id;
            using (var httpClient = new HttpClient())
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
