using DataLibraryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppForData.Controllers
{
    public class HomeController : Controller
    {
        CDataAccess dataAccess = new CDataAccess();

        [HttpGet]
        public ActionResult Index()
        {
            return View(dataAccess.GetAllEmployees());
        }
        public ActionResult AddEmployee()
        {
            return View(new Employee());
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            dataAccess.AddEmployee(emp);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveEmployee(int id)
        {
            dataAccess.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        public ActionResult EditEmployee(int id)
        {
            var employee = (from emp in dataAccess.GetAllEmployees() where emp.EId == id select emp).First();
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee emp)
        {
            dataAccess.ModifyEmployee(emp);
            return RedirectToAction("Index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}