using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppValidation.Models;

namespace WebAppValidation.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Appointment { Date = DateTime.Now });
        }
        [HttpPost]
        public ActionResult Index(Appointment appt)
        {
            //if (string.IsNullOrEmpty(appt.DoctorName))
            //{
            //    ModelState.AddModelError("DoctorName", "Please Enter the name");
            //}
            //if (ModelState.IsValidField("Date") && DateTime.Now > appt.Date)
            //{
            //    ModelState.AddModelError("Date", "Please Enter the future date");
            //}
            //if (!appt.TermsAccepted)
            //{
            //    ModelState.AddModelError("TermsAccepted", "Please Accept the terms");
            //}

            //if (ModelState.IsValidField("DoctorName") && ModelState.IsValidField("Date")
            //    && appt.DoctorName.ToLower() == "rahul" && appt.Date.DayOfWeek == DayOfWeek.Monday
            //    )
            //{
            //    ModelState.AddModelError("", "Rahul is not available on monday!!!");
            //}

            if (ModelState.IsValid)
            {
                return View("Completed", appt);
            }
            else
            {
                return View();
            }
        }

    }
}