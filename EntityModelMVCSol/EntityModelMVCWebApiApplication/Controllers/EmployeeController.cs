using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using EntityModelMVC;
using EntityModelMVC.Properties;

namespace EntityModelMVCWebApiApplication.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly DataAccess dataAccess = new DataAccess();

        //GET: /api/Employee
        [HttpGet]
        public IEnumerable<EMPLOYEE> GetAllEmployees()
        {
            var employees = dataAccess.GetAllEmployees();
            return employees;
        }

        [HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var employee = dataAccess.GetEmployeeById(id);
            if (employee == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = "Employee not found", EmployeeId = id });
            }
            return Ok(employee);
        }

        [HttpPost]
        public IHttpActionResult AddEmployee(EMPLOYEE employee)
        {
            if (employee == null)
            {
                return Content(HttpStatusCode.BadRequest, new { Message = "Employee data is missing" });
            }
            dataAccess.AddEmployee(employee);
            return Content(HttpStatusCode.Created, new { Message = "Employee added successfully", EmployeeAdded=employee });
        }

        [HttpPut]
        public IHttpActionResult EditEmployee(EMPLOYEE employee)
        {
            if (employee == null)
            {
                return Content(HttpStatusCode.BadRequest, new { Message = "Employee data is missing" });
            }
            var existingEmployee = dataAccess.GetEmployeeById(employee.EId);
            if (existingEmployee != null)
            {
                dataAccess.ModifyEmployee(employee);
                return Content(HttpStatusCode.OK, new { Message = "Employee modified successfully", EmployeeModified=employee });
            }
            return Content(HttpStatusCode.NotFound, new { Message = "Employee not found", EmployeeId = employee.EId });
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = dataAccess.GetEmployeeById(id);
            if(employee == null)
            {
                return Content(HttpStatusCode.NotFound, new { Message = "Employee not found", EmployeeId = id });
            }
            dataAccess.DeleteEmployee(id);
            return Content(HttpStatusCode.OK, new { Message = "Employee deleted successfully", DeleteEmployeeId=id });

        }
    }
}