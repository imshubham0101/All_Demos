using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Mydb
{
    class Program
    {
       
        static void Main(string[] args)
        {
            SqlServer db = new SqlServer();
            var emps = db.Select();
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.GetDetails());
            }
            int rowsAffected = db.Insert(Emp emp);
           



        }
    }

    public class SqlServer
    {
        public List<Emp> Select()
        {
            List<Emp> emps = new List<Emp>() ;
            string meraConn = ConfigurationManager.ConnectionStrings["myconstr"].ToString();
            SqlConnection con = new SqlConnection(meraConn);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Employee", con);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Emp emp = new Emp();

                emp.No = Convert.ToInt32(reader[0]);
                emp.Name = reader[1].ToString();
                emp.Address = reader[2].ToString();

                emps.Add(emp);
                

            }
            return emps;
        }

        public int Insert(Emp emp)
        {
            List<Emp> emps = new List<Emp>();
            string myCon = ConfigurationManager.ConnectionStrings["myconstr"].ToString();
            SqlConnection con = new SqlConnection("myCon");

            con.Open();

            string query = "insert into Employee values({0},'{1}','{2}')";
            string finalQuery = string.Format(query, emp.No, emp.Name, emp.Address);
            SqlCommand cmd = new SqlCommand(finalQuery, con);
            int noOfRowsAffected = cmd.ExecuteNonQuery(); 
            return noOfRowsAffected ;

        }
    }
    public class Emp
    {
        
        private int _No;

        public int No 
        {
            get { return _No; }
            set { _No = value; }
        }

      
        private string _Name ;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private string _Address;

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string GetDetails()
        {
            return string.Format("No .{0} :: Name: {1}   Address: {2} ",No,Name,Address);

        }


    }


}
