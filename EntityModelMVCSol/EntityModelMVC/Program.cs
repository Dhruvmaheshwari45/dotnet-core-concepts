using EntityModelMVC.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModelMVC
{
    public class DataAccess
    {
        public List<EMPLOYEE> GetAllEmployees()
        {
            using(CdacDemo1Entities cdacDemo1Entities = new CdacDemo1Entities())
            {
                List<EMPLOYEE> list = (from emp in cdacDemo1Entities.EMPLOYEEs select emp).ToList();
                return list;
            }
        }

        public EMPLOYEE GetEmployeeById(int id)
        {
            using(CdacDemo1Entities cdacDemo1Entities = new CdacDemo1Entities())
            {
                EMPLOYEE employee = (from emp in cdacDemo1Entities.EMPLOYEEs
                                     where emp.EId == id
                                     select emp).FirstOrDefault();
                return employee;
            }
        }

        public void AddEmployee(EMPLOYEE employee)
        {
            using(CdacDemo1Entities cdacDemo1Entities = new CdacDemo1Entities())
            {
                cdacDemo1Entities.EMPLOYEEs.Add(employee);
                cdacDemo1Entities.SaveChanges();
            }
        }

        public void ModifyEmployee(EMPLOYEE employee)
        {
            using(CdacDemo1Entities cdacDemo1Entities = new CdacDemo1Entities())
            {
                var existingEmployee = (from emp in cdacDemo1Entities.EMPLOYEEs
                                        where emp.EId == employee.EId
                                        select emp).FirstOrDefault();
                if(existingEmployee != null)
                {
                    existingEmployee.EName = employee.EName;
                    existingEmployee.DeptId = employee.DeptId;

                    cdacDemo1Entities.SaveChanges();
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            using(CdacDemo1Entities cdacDemo1Entities = new CdacDemo1Entities())
            {
                var existingEmployee = (from emp in cdacDemo1Entities.EMPLOYEEs
                                        where emp.EId == id
                                        select emp).FirstOrDefault();

                if(existingEmployee != null)
                {
                    cdacDemo1Entities.EMPLOYEEs.Remove(existingEmployee);
                    cdacDemo1Entities.SaveChanges();
                }
            }
        }
        static void Main(string[] args)
        {

        }
    }
}
