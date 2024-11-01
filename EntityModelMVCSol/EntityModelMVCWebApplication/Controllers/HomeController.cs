using EntityModelMVC;
using EntityModelMVC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityModelMVCWebApplication.Controllers
{
    public class HomeController : Controller
    {
        DataAccess dataAccess = new DataAccess();

        public ActionResult Index()
        {
            var employee = dataAccess.GetAllEmployees();
            return View(employee);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EMPLOYEE employee)
        {
            dataAccess.AddEmployee(employee);
            return RedirectToAction("Index");
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

        //[HttpPost]
        //public ActionResult Edit(EMPLOYEE employee)
        //{
        //    dataAccess.ModifyEmployee(employee)
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public ActionResult Edit(EMPLOYEE employee)
        {
            if (ModelState.IsValid)
            {
                dataAccess.ModifyEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        public ActionResult Delete(int id)
        {
            var employee = dataAccess.GetEmployeeById(id);
            if(employee == null)
            {
                return HttpNotFound();
            }
            dataAccess.DeleteEmployee(id);
            return RedirectToAction("Index");   
        }
        
    }
}