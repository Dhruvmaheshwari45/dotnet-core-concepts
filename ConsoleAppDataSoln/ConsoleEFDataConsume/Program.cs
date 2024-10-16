using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibraryEF;

namespace ConsoleEFDataConsume
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CDataAccess dalEf = new CDataAccess();
            //dalEf.AddEmployee(new Employee { EId = 159, EName = "piyush", Dept = 50 });

            //dalEf.ModifyEmployee(new Employee { EId = 159, EName = "Piyush Anand", Dept = 50 });
            //dalEf.DeleteEmployee(130);
            List<Employee> listEmployees = dalEf.GetAllEmployees();
            Console.WriteLine($"{"EmpId",-20} {"EmpName",-20} {"EmpDept",-20}");

            foreach (var emp in listEmployees)
            {
                Console.WriteLine($"{emp.EId,-20} {emp.EName,-20} {emp.Dept,-20}");
            }
        }
    }
}
