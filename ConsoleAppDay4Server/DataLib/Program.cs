using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class EmpOrm
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; } = string.Empty;
        public int DeptId { get; set; }
    }
    public class CDataLib
    {
        private readonly string cnnStr;
        SqlConnection conn;
        SqlCommand cmd;

        public CDataLib(string cnnStr)
        {
            this.cnnStr = cnnStr;
            conn = new SqlConnection(cnnStr);
            cmd = conn.CreateCommand();
            cmd.Connection = conn;
        }

        public IEnumerable<EmpOrm> GetEmployees()
        {
            List<EmpOrm> list = new List<EmpOrm>();
            cmd.CommandText = "select * from Employee";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new EmpOrm
                {
                    EmpId = reader.GetInt32(0),
                    EmpName = reader.GetString(1),
                    DeptId = reader.GetInt32(2)
                });
            }
            reader.Close();
            conn.Close();
            return list;
        }

        public EmpOrm GetEmpById(int id)
        {
            List<EmpOrm> list = new List<EmpOrm>();
            cmd.CommandText = $"select * from Employee where EmpId = {id}";

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                list.Add(new EmpOrm
                {
                    EmpId = reader.GetInt32(0),
                    EmpName = reader.GetString(1),
                    DeptId = reader.GetInt32(2)
                });
            }
            reader.Close();
            conn.Close();

            return list.Count == 0 ? null : list[0];
        }

        public bool ModifyEmp(EmpOrm emp)
        {
            cmd.CommandText = $"update Employee set EName = '{emp.EmpName}', Dept = {emp.DeptId} where EId = {emp.EmpId}";
            System.Console.WriteLine(cmd.CommandText);
            conn.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            conn.Close();
            return rowsAffected > 0;
        }

        public bool DeleteEmp(int id)
        {
            cmd.CommandText = $"delete employee where EId = {id}";
            conn.Open();

            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected > 0;
        }

        public bool AddEmp(EmpOrm emp)
        {
            cmd.CommandText = $"insert into  employee values({emp.EmpId},'{emp.EmpName}',{emp.DeptId})";
            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsAffected > 0;
        }
        static void Main(string[] args)
        {

        }
    }
}