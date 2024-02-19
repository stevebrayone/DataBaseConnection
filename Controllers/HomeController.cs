using DataBaseConnection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using DataBaseConnection.Models;

namespace DataBaseConnection.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            //CREATE
            //SqlConnection connection = new SqlConnection("/*Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Steve;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False*/");
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Steve;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"; 
            //string insertQuary = "INSERT INTO employee(employee_name)VALUES(@name)";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //string createTableQuery = "CREATE TABLE employee(employee_id INT PRIMARY KEY IDENTITY(1,1),employee_name VARCHAR(40))";
            //    using (SqlCommand cmd = new SqlCommand(insertQuary, connection))
            //    {
            //        cmd.Parameters.AddWithValue("@name", "SteveBrayone");
            //        cmd.ExecuteNonQuery();
            //    }
            //}
            //return View();


            //DELETE
            //    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Steve;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //    string deleteQuary = "DELETE FROM employee where employee_id=1";
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();
            //        using (SqlCommand cmd = new SqlCommand(deleteQuary, connection))
            //        {
            //            cmd.Parameters.AddWithValue("@name", "mariya");
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    return View();

            //}




            //UPDATE
            //string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Steve;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            //string updateQuary = "ALTER TABLE employee ADD age INT default 5 NOT NULL ";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    using (SqlCommand cmd = new SqlCommand(updateQuary, connection))
            //    {
            //        cmd.Parameters.AddWithValue("@col", "age");
            //        cmd.ExecuteNonQuery();
            //    }
            //}
            //return View();
            //selectionOrView
            List<Employee> employee_detials = new List<Employee>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Steve;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT employee_id,employee_name FROM employee";
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql,connection)) 
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employee_detials.Add(new Employee
                            {
                                EmployeeId = reader.GetInt32(0),
                                EmployeeName = reader.GetString(1)
                            });
                        }
                    }
                    return View(employee_detials);
                }
            }
        }
    }
}