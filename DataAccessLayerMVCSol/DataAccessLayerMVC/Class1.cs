using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmpOrm
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DeptId { get; set; }
    }
    public class DataAccess
    {
        private readonly string connStr;
        SqlConnection conn;
        SqlCommand cmd;

        public DataAccess(string connStr)
        {
            this.connStr = connStr;
            conn = new SqlConnection(connStr);
            cmd = conn.CreateCommand();
            cmd.Connection = conn;
        }

        public IEnumerable<EmpOrm> GetAllEmployee()
        {
            List<EmpOrm> list = new List<EmpOrm>();
            cmd.CommandText = $"select * from Employee";
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

        public EmpOrm GetEmployeeById(int id)
        {
            List<EmpOrm> list = new List<EmpOrm>();
            cmd.CommandText = $"select * from Employee where EId = {id}";
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

            if(list.Count == 0)
            {
                return null;
            }
            return list[0];
        }

        public bool AddEmployee(EmpOrm emp)
        {
            cmd.CommandText = $"Insert into Employee values({emp.EmpId}, '{emp.EmpName}', {emp.DeptId})";
            conn.Open();
            int rowsEffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsEffected > 0;
        }

        public bool ModifyEmployee(EmpOrm emp)
        {
            cmd.CommandText = $"update Employee set EName = '{emp.EmpName}', DeptId = {emp.DeptId} where EId = {emp.EmpId}";
            System.Console.WriteLine(cmd.CommandText);
            conn.Open();
            int rowsEffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsEffected > 0;
        }

        public bool RemoveEmployee(int id)
        {
            cmd.CommandText = $"Delete from Employee where EId = {id}";
            conn.Open();
            int rowsEffected = cmd.ExecuteNonQuery();
            conn.Close();
            return rowsEffected > 0;
        }

        static void Main(string[] args)
        {

        }

    }
}
