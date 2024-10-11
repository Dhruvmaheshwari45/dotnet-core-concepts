using MainMvc.Models.Abstract;
using MainMvc.Models.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainMvc.Controllers
{
    public class HomeController : Controller
    {
        ICustomerDal dal;

        public HomeController()
        {
            dal = new FakeRepo();
        }
        public ActionResult Index()
        {
            return View(dal.GetAll());
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            //Customer cust = new Customer();
            //return View(cust);

            return View(new Customer());
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer cust)
        {
            dal.AddCustomer(cust);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public ActionResult RemoveCustomer(int id)
        {
            dal.DeleteCustomer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ModifyCustomer(int id)
        {
            var cust = dal.Get(id);
            return View(cust);
        }

        [HttpPost]
        public ActionResult ModifyCustomer(Customer cust)
        {
            dal.UpdateCustomer(cust);
            return RedirectToAction("Index");
        }

    }
}