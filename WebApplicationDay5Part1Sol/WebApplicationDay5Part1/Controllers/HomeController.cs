using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationDay5Part1.Models;

namespace WebApplicationDay5Part1.Controllers
{
    public class HomeController : Controller
    {
        List<Person> people = new List<Person>();
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            Person person = new Person();
            ViewBag.People = people;
            return View(person);
        }

        [HttpPost]
        public ActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            people.Add(person);
            return View("Thanks", person);
        }
    }
}