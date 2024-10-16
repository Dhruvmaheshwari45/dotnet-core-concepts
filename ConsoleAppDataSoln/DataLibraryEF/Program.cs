using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibraryEF
{
    public class CDataAccess
    {
        public  List<Employee> GetAllEmployees()
        { 
           DacWondersEntities dacWondersEntities = new DacWondersEntities();
            List<Employee> list = (from emp in dacWondersEntities.Employees select emp).ToList();
            return list;
        }

        public  void AddEmployee(Employee emp)
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                dacWondersEntities.Employees.Add(emp);
                dacWondersEntities.SaveChanges();
            }
        }

        public void ModifyEmployee(Employee empToBeModified)
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.EId == empToBeModified.EId
                                   select emp).First();

                empSelected.EName = empToBeModified.EName;
                empSelected.Dept = empToBeModified.Dept;

                dacWondersEntities.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.EId == id
                                   select emp).First();

                dacWondersEntities.Employees.Remove(empSelected);
                dacWondersEntities.SaveChanges();
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
