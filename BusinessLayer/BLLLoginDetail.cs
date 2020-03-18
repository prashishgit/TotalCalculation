using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLLoginDetail
    {
        public int AddLoginDetail(LoginDetails ld)
        {
            SqlConnection con = new SqlConnection(@"Data Source=PRASHISH\SQLEXPRESS;Integrated Security=true; Database=BroadwayDB");
            SqlCommand cmd = new SqlCommand("insert into tblLoginDetail values(@a,@b,@c,@d);SELECT SCOPE_IDENTITY();", con);
            cmd.Parameters.AddWithValue("@a", ld.UserId);
            cmd.Parameters.AddWithValue("@b", ld.LoginTime);
            cmd.Parameters.AddWithValue("@c", ld.LogoutTime);
            cmd.Parameters.AddWithValue("@d", ld.LoginDate);


            con.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            return i;
        }
        public int Logoutupdate(LoginDetails ld)
        {
            SqlConnection con = new SqlConnection("Data Source=PRASHISH\\SQLEXPRESS;Integrated Security=true; Database=BroadwayDB");
            SqlCommand cmd = new SqlCommand("update tblLoginDetail set LogoutTime=@a where LoginDetailId=@b and UserId=@c", con);
            cmd.Parameters.AddWithValue("@a", ld.LogoutTime);
            cmd.Parameters.AddWithValue("@b", ld.LoginDetailId);
            cmd.Parameters.AddWithValue("@c", ld.UserId);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
    }
}
