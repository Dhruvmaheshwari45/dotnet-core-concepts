using DataLibEF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApplicationApiMvcDemo.Controllers;

namespace MvcUnitTestEmployee
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _employeeController;
        private List<Employee> _employeeList;

        [SetUp]
        public void SetUp()
        {
            // Initialize the controller and a sample in-memory employee list
            _employeeList = new List<Employee>
            {
                new Employee { EId = 101, EName = "John", Dept = 10 },
                new Employee { EId = 102, EName = "Jane", Dept = 20 }
            };

            _employeeController = new EmployeeController(_employeeList);
        }

        [Test]
        public void Post_AddsEmployee_ReturnsCreatedStatus()
        {
            // Arrange
            var newEmployee = new Employee { EId = 105, EName = "Piyush", Dept = 30 };

            // Act
            IHttpActionResult result = _employeeController.AddEmployee(newEmployee);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.Created, statusCodeResult.StatusCode);
            Assert.IsTrue(_employeeList.Any(e => e.EId == newEmployee.EId));  // Verify employee is added
        }

        [Test]
        public void Put_UpdatesEmployee_ReturnsNoContent()
        {
            // Arrange
            var updatedEmployee = new Employee { EId = 101, EName = "John Updated", Dept = 15 };

            // Act
            IHttpActionResult result = _employeeController.UpdateEmployee(101, updatedEmployee);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
            Assert.AreEqual("John Updated", _employeeList.First(e => e.EId == 101).EName);  // Verify update
        }

        [Test]
        public void Delete_RemovesEmployee_ReturnsNoContent()
        {
            // Act
            IHttpActionResult result = _employeeController.DeleteEmployee(101);

            // Assert
            Assert.IsInstanceOf<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
            Assert.IsFalse(_employeeList.Any(e => e.EId == 101));  // Verify employee is removed
        }
    }
}
