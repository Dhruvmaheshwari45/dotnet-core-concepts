using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;  // Ensure Moq is installed via NuGet
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using DataLibEF;
using WebApplicationApiMvcDemo.Controllers;
using System.Net.Http;

namespace MVCEmployeeUnitTestProject2
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private EmployeeController _employeeController;
        private List<Employee> _employeeList;
        private Mock<CDataLibEF> _mockDataLibEF;

        [TestInitialize]
        public void SetUp()
        {
            _employeeList = new List<Employee>
            {
                new Employee { EId = 190, EName = "John Gita", Dept = 10 },
                new Employee { EId = 191, EName = "Jane Pragat", Dept = 20 }
            };

            _mockDataLibEF = new Mock<CDataLibEF>();

            // Setup mock methods
            _mockDataLibEF.Setup(x => x.GetAllEmployee()).Returns(_employeeList);
            _mockDataLibEF.Setup(x => x.AddEmployee(It.IsAny<Employee>())).Callback<Employee>(emp => _employeeList.Add(emp));
            _mockDataLibEF.Setup(x => x.ModifyEmployee(It.IsAny<Employee>())).Callback<Employee>(emp =>
            {
                var existingEmp = _employeeList.FirstOrDefault(e => e.EId == emp.EId);
                if (existingEmp != null)
                {
                    existingEmp.EName = emp.EName;
                    existingEmp.Dept = emp.Dept;
                }
            });
            _mockDataLibEF.Setup(x => x.DeleteEmployee(It.IsAny<int>())).Callback<int>(id =>
            {
                var emp = _employeeList.FirstOrDefault(e => e.EId == id);
                if (emp != null)
                {
                    _employeeList.Remove(emp);
                }
            });

            _employeeController = new EmployeeController
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Injecting the mock dependency
            typeof(EmployeeController)
                .GetField("cDataLibEF", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                ?.SetValue(_employeeController, _mockDataLibEF.Object);
        }

        [TestMethod]
        public void AddEmployee_ReturnsCreatedStatus()
        {
            // Arrange
            var newEmployee = new Employee { EId = 192, EName = "John Doe", Dept = 30 };

            // Act
            IHttpActionResult result = _employeeController.AddEmployee(newEmployee);

            // Assert
            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            var statusCodeResult = result as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.Created, statusCodeResult.StatusCode);
            Assert.IsTrue(_employeeList.Any(e => e.EId == newEmployee.EId));  // Verify employee is added
        }

        [TestMethod]
        public void GetAllEmployees_ReturnsAllEmployees()
        {
            // Act
            var result = _employeeController.GetAllEmployees();

            // Assert
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("John Gita", result.First().EName);
        }

        [TestMethod]
        public void GetEmployee_ExistingId_ReturnsEmployee()
        {
            // Act
            IHttpActionResult actionResult = _employeeController.GetEmployee(190);
            var contentResult = actionResult as OkNegotiatedContentResult<Employee>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(190, contentResult.Content.EId);
        }

        [TestMethod]
        public void GetEmployee_NonExistingId_ReturnsNotFound()
        {
            // Act
            IHttpActionResult actionResult = _employeeController.GetEmployee(999);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void UpdateEmployee_ExistingId_ReturnsNoContent()
        {
            // Arrange
            var updatedEmployee = new Employee { EId = 190, EName = "John Updated", Dept = 15 };

            // Act
            IHttpActionResult actionResult = _employeeController.UpdateEmployee(190, updatedEmployee);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(StatusCodeResult));
            var statusCodeResult = actionResult as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
            Assert.AreEqual("John Updated", _employeeList.First(e => e.EId == 190).EName);  // Verify update
        }

        [TestMethod]
        public void UpdateEmployee_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var updatedEmployee = new Employee { EId = 999, EName = "Non Existing", Dept = 15 };

            // Act
            IHttpActionResult actionResult = _employeeController.UpdateEmployee(999, updatedEmployee);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DeleteEmployee_ExistingId_ReturnsNoContent()
        {
            // Act
            IHttpActionResult actionResult = _employeeController.DeleteEmployee(190);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(StatusCodeResult));
            var statusCodeResult = actionResult as StatusCodeResult;
            Assert.AreEqual(HttpStatusCode.NoContent, statusCodeResult.StatusCode);
            Assert.IsFalse(_employeeList.Any(e => e.EId == 190));  // Verify employee is removed
        }

        [TestMethod]
        public void DeleteEmployee_NonExistingId_ReturnsNotFound()
        {
            // Act
            IHttpActionResult actionResult = _employeeController.DeleteEmployee(999);

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }
    }
}
