using DataLibEF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebApplicationApiMvcDemo.Controllers;

namespace WebApplicationMvcDemoUnitTestProject1
{
    [TestClass]
    public class EmployeeControllerTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // Reset the static data before each test
            EmployeeController.empDatas = new List<Employee>
            {
                new Employee { EId = 101, EName = "John", Dept = 10 },
                new Employee { EId = 102, EName = "saurav", Dept = 20 },
                new Employee { EId = 103, EName = "rahul", Dept = 10 },
                new Employee { EId = 104, EName = "sewag", Dept = 20 }
            };
        }

        [TestMethod]
        public void Post_ShouldAddEmployee()
        {
            // Arrange
            var controller = new EmployeeController();
            var newEmployee = new Employee { EId = 105, EName = "Dhoni", Dept = 10 };

            // Act
            var result = controller.Post(newEmployee);

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, result);
            Assert.IsTrue(EmployeeController.empDatas.Any(emp => emp.EId == 105));
        }

        [TestMethod]
        public void Delete_ShouldDeleteEmployee()
        {
            //Arrange
            var controller = new EmployeeController();
            var empId = 101;

            //Act
            var result = controller.Delete(empId);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result);
            Assert.AreNotEqual(HttpStatusCode.NoContent, result);
        }
    }
}
