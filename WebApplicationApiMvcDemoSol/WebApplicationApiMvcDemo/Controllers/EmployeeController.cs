using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DataLibEF;
using System.Net;
using System.Net.Http;

namespace WebApplicationApiMvcDemo.Controllers
{
    public class EmployeeController : ApiController
    {

        private readonly CDataLibEF cDataLibEF = new CDataLibEF();

        // GET: api/Employee

        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = cDataLibEF.GetAllEmployee();
            return employees;
        }

        // GET: api/Employee/id
        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = cDataLibEF.GetAllEmployee().FirstOrDefault(emp => emp.EId == id);
            if(employee == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, new { Message = "Employee not found", EmployeeId = id });
            }
            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public IHttpActionResult AddEmployee(Employee emp)
        {
            if(emp == null)
            {
                return BadRequest("Employee data is null");
            }
            cDataLibEF.AddEmployee(emp);
            //return StatusCode(HttpStatusCode.Created);
            return Content(HttpStatusCode.Created, new { Message = "Employee added successfully", Employee = emp });
        }

        //PUT: api/Employee/id
        //[HttpPut]
        //public IHttpActionResult UpdateEmployee(int id, Employee emp)
        //{
        //    if(emp==null || emp.EId != id)
        //    {
        //        return BadRequest("Employee data is null or id is not matching");
        //    }
        //    var existingEmployee = cDataLibEF.GetAllEmployee().FirstOrDefault(e => e.EId == id);
        //    if(existingEmployee == null)
        //    {
        //        return NotFound();
        //    }
        //    cDataLibEF.ModifyEmployee(emp);
        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //PUT: api/Employee/id
        [HttpPut]
        public IHttpActionResult UpdateEmployee(Employee emp)
        {
            if(emp == null)
            {
                return BadRequest("Employee data is null");
            }
            var existingEmployee = cDataLibEF.GetAllEmployee().FirstOrDefault(e => e.EId == emp.EId);
            if(existingEmployee == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, new { Message = "Employee not found", EmployeeId = emp.EId });
            }

            cDataLibEF.ModifyEmployee(emp);
            //return StatusCode(HttpStatusCode.NoContent);
            return Content(HttpStatusCode.OK, new { Message = "Employee updated successfully", Employee = emp });
        }

        //DELETE: api/Employee/id
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = cDataLibEF.GetAllEmployee().FirstOrDefault(emp => emp.EId == id);
            if (employee == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, new { Message = "Employee not found", EmployeeId = id });
            }
            cDataLibEF.DeleteEmployee(id);
            //return StatusCode(HttpStatusCode.NoContent);
            return Content(HttpStatusCode.OK, new { Message = "Employee deleted successfully", DeletedEmployeeId = id });
        }


        // GET: Employee
        //public static List<Employee> empDatas = new List<Employee>();

        //static EmployeeController()
        //{
        //    empDatas.Add(new Employee { EId = 101, EName = "John", Dept = 10 });
        //    empDatas.Add(new Employee { EId = 102, EName = "saurav", Dept = 20 });
        //    empDatas.Add(new Employee { EId = 103, EName = "rahul", Dept = 10 });
        //    empDatas.Add(new Employee { EId = 104, EName = "sewag", Dept = 20 });
        //}

        //public IEnumerable<Employee> Get()
        //{
        //    return empDatas;
        //}

        //public IEnumerable<Employee> Get(int id)
        //{
        //    return empDatas.Where(emp => emp.EId == id);
        //}


        //public HttpStatusCode Post(Employee emp)
        //{
        //    if(emp == null)
        //    {
        //        return HttpStatusCode.BadRequest;
        //    }
        //    empDatas.Add(emp);
        //    return HttpStatusCode.Created;
        //}

        //public HttpStatusCode Delete(int id)
        //{
        //    empDatas = empDatas.Where(emp => emp.EId != id).ToList();
        //    return HttpStatusCode.OK;
        //}
    }
}