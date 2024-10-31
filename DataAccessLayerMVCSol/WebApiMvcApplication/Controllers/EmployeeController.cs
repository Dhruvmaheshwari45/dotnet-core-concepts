using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using DataAccessLayer;
using System.Configuration;

namespace WebApiMvcApplication.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly DataAccess dataAccess;
        public EmployeeController()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConn"].ConnectionString;
            dataAccess = new DataAccess(connStr);
        }

        //GET: /api/Employee
        [HttpGet]
        public IEnumerable<EmpOrm> GetAllEmployee()
        {
            var employees = dataAccess.GetAllEmployee();
            return employees;

        }

        //GET: /api/Employee/id
        [HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var employee = dataAccess.GetEmployeeById(id);
            if (employee == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = "Employee Not found" });
            }
            return Ok(employee);
        }

        //POST: /api/Employee

        [HttpPost]
        public IHttpActionResult AddEmployee(EmpOrm emp)
        {
            if (emp == null)
            {
                return BadRequest("Given Employee Data is null");
            }
            dataAccess.AddEmployee(emp);
            return Content(HttpStatusCode.Created, new { Message = "Employee Added Successfully", EmpOrm = emp });
        }

        //PUT: /api/Employee/id
        [HttpPut]
        public IHttpActionResult ModifyEmployee(EmpOrm emp)
        {
            if (emp == null)
            {
                return BadRequest("Employee data is null");
            }
            var existingEmployee = dataAccess.GetEmployeeById(emp.EmpId);
            if (existingEmployee == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = "Employee Not found", EmployeeId = emp.EmpId });
            }
            dataAccess.ModifyEmployee(emp);
            return Content(HttpStatusCode.OK, new { Message = "Employee updated successfully", Employee = emp });
        }

        //DELETE: /api/Employee/id
        [HttpDelete]
        public IHttpActionResult RemoveEmployee(int id)
        {
            var employee = dataAccess.GetEmployeeById(id);
            if (employee == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = "Employee not found", EmployeeId = id });
            }
            dataAccess.RemoveEmployee(id);
            return Content(HttpStatusCode.OK, new { Message = "Employee removed successfully", EmployeeId = id });

        }
    }
}