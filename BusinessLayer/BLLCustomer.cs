using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLCustomer
    {
        public int CreateCustomer(CustomerDetails cd)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("insert into tblCustomer values(@a,@b,@c)", con);
            cmd.Parameters.AddWithValue("@a", cd.CustomerName);
            cmd.Parameters.AddWithValue("@b", cd.Email);
            cmd.Parameters.AddWithValue("@c", cd.Phone);


            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            return i;
        }
        public List<CustomerDetails> GetAllCustomers()
        {
            List<CustomerDetails> list = new List<CustomerDetails>();
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("select * from tblCustomer", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CustomerDetails cd = new CustomerDetails();
                cd.CustomerId = (int)dr["CustomerId"];
                cd.CustomerName = (string)dr["CustomerName"];
                cd.Email = (string)dr["Email"];
                cd.Phone = (string)dr["Phone"];

                list.Add(cd);
            }
            dr.Close();
            con.Close();
            return list;
        }
    }
}
