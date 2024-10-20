using PatientRecordEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PatientRecordApiMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly string apibaseurl = "https://localhost:44314/api/PatientRecord";

        private async Task<List<Patientrecord>> GetPatientRecordAsync()
        {
            List<Patientrecord> patientrecord = new List<Patientrecord>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apibaseurl);
                HttpResponseMessage response = await httpClient.GetAsync("Patientrecord");

                if (response.IsSuccessStatusCode)
                {
                    patientrecord = await response.Content.ReadAsAsync<List<Patientrecord>>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return patientrecord;
        }

        private async Task<Patientrecord> GetPatientRecordByIdAsync(string id)
        {
            Patientrecord patientrecord = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apibaseurl);
                HttpResponseMessage response = await httpClient.GetAsync($"Patientrecord/{id}");

                if (response.IsSuccessStatusCode)
                {
                    patientrecord = await response.Content.ReadAsAsync<Patientrecord>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return patientrecord;
        }

        private async Task<List<Patientrecord>> GetPatientRecordsByConditionAsync(string condition)
        {
            List<Patientrecord> patientrecords = new List<Patientrecord>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apibaseurl);
                HttpResponseMessage response = await httpClient.GetAsync($"Patientrecord/condition/{condition}");

                if (response.IsSuccessStatusCode)
                {
                    patientrecords = await response.Content.ReadAsAsync<List<Patientrecord>>();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return patientrecords;
        }

        public async Task<ActionResult> Index()
        {
            ViewBag.Title = "Home Page";

            List<Patientrecord> patientrecord = await GetPatientRecordAsync();

            return View(patientrecord);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Patientrecord patientrecord = await GetPatientRecordByIdAsync(id);

            if (patientrecord == null)
            {
                return HttpNotFound();
            }

            return View(patientrecord);
        }

        public async Task<ActionResult> ByCondition(string condition)
        {
            if (string.IsNullOrEmpty(condition))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            List<Patientrecord> patientrecords = await GetPatientRecordsByConditionAsync(condition);

            return View(patientrecords);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Patientrecord patientrecord)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apibaseurl);
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("Patientrecord", patientrecord);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(patientrecord);
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Patientrecord patientrecord = await GetPatientRecordByIdAsync(id);

            if (patientrecord == null)
            {
                return HttpNotFound();
            }

            return View(patientrecord);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Patientrecord patientrecord)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apibaseurl);
                HttpResponseMessage response = await httpClient.PutAsJsonAsync($"Patientrecord/{patientrecord.id}", patientrecord);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(patientrecord);
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Patientrecord patientrecord = await GetPatientRecordByIdAsync(id);

            if (patientrecord == null)
            {
                return HttpNotFound();
            }

            return View(patientrecord);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(apibaseurl);
                HttpResponseMessage response = await httpClient.DeleteAsync($"Patientrecord/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return RedirectToAction("Delete", new { id });
        }
    }
}
