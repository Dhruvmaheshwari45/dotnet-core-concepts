using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLib;
using System.Configuration;

namespace SqlConnection
{
    internal class Program
    {
        static void Show_Employee(IEnumerable<EmpOrm> employees)
        {
            Console.WriteLine("{0, -10}, {1, -20}, {2, -10}", "EID", "ENAME", "DEPT");
            foreach (var emp in employees)
            {
                Console.WriteLine("{0, -10}, {1, -20}, {2, -10}", emp.EmpId, emp.EmpName, emp.DeptId);
            }
        }

        static void Main(string[] args)
        {
            //string cnnStr = ConfigurationManager.ConnectionStrings["MySqlCnn"].ConnectionString;
            string cnnStr = ConfigurationManager.ConnectionStrings["MySqlCnn"].ConnectionString;
            CDataLib dal = new CDataLib(cnnStr);
            var employees = dal.GetEmployees();
            Show_Employee(employees);

            EmpOrm empOrm = new EmpOrm();
            empOrm.EmpId = 129;
            empOrm.EmpName = "Raju Rastogi";
            empOrm.DeptId = 103;
            dal.AddEmp(empOrm);

            EmpOrm empOrm2 = new EmpOrm();
            empOrm2.EmpId = 104;
            empOrm2.EmpName = "Khan";
            empOrm2.DeptId = 30;
            dal.ModifyEmp(empOrm2);

            dal.DeleteEmp(108);

            Show_Employee(dal.GetEmployees());
        }
    }
}
