using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppData
{
    internal class Program
    {
        static void MainSelect()
        {
            //DacWondersEntities dacWondersEntities = new DacWondersEntities();
            //var listEmployees = from emp in dacWondersEntities.Employees select emp;

            //Console.WriteLine($"{"EmpId", -20} {"EmpName", -20} {"EmpDept", -20}");

            //foreach(var emp in listEmployees)
            //{
            //    Console.WriteLine($"{emp.EId,-20} {emp.EName,-20} {emp.Dept,-20}");
            //}
            //dacWondersEntities.Dispose();

            using(DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var listEmployees = from emp in dacWondersEntities.Employees select emp;

                Console.WriteLine($"{"EmpId",-20} {"EmpName",-20} {"EmpDept",-20}");

                foreach (var emp in listEmployees)
                {
                    Console.WriteLine($"{emp.EId,-20} {emp.EName,-20} {emp.Dept,-20}");
                }
            }
        }

        static void MainAdd()
        {
            using (DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                Employee emp = new Employee { EId = 101, EName = "Sachin Tendulkar", Dept = 10 };
                dacWondersEntities.Employees.Add(emp);
                dacWondersEntities.SaveChanges();
                //Employee emp = new Employee { EId = 116, EName = "Anil Kumble", Dept = 10 };
                //dacWondersEntities.Employees.Add(emp);
                //dacWondersEntities.SaveChanges();
            }
            MainSelect();
        }

        static void MainUpdate()
        {
            using(DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.EId == 116
                                   select emp).First();

                empSelected.EName = "Anil Jagannath Kumble";
                empSelected.Dept = 50;

                dacWondersEntities.SaveChanges();
            }
            MainSelect();
        }

        static void Main()
        {
            using(DacWondersEntities dacWondersEntities = new DacWondersEntities())
            {
                var empSelected = (from emp in dacWondersEntities.Employees
                                   where emp.EId == 116
                                   select emp).First();

                dacWondersEntities.Employees.Remove(empSelected);
                dacWondersEntities.SaveChanges();
            }
            MainSelect();
        }
    }
}
