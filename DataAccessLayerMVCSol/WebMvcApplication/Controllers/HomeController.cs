using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMvcApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataAccess dataAccess;

        public HomeController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            dataAccess = new DataAccess(connStr);
        }

        public ActionResult Index()
        {
            var employees = dataAccess.GetAllEmployee();
            return View(employees);
        }

        public ActionResult Details(int id)
        {
            var employee = dataAccess.GetEmployeeById(id);
            if(employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EmpOrm emp)
        {
            if (ModelState.IsValid)
            {
                dataAccess.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public ActionResult Edit(int id)
        {
            var employee = dataAccess.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(EmpOrm emp)
        {
            if (ModelState.IsValid)
            {
                dataAccess.ModifyEmployee(emp);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public ActionResult Delete(int id) 
        {
            var employee = dataAccess.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            dataAccess.RemoveEmployee(id);
            return RedirectToAction("Index");
        }
    }
}