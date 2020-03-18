using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLUser
    {
        public List<UserTypeDetails> GetAllUserType()
        {
            List<UserTypeDetails> list = new List<UserTypeDetails>();
            SqlConnection con = new SqlConnection("Data Source=PRASHISH\\SQLEXPRESS; Integrated Security=true; Database=BroadwayDB;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblUserType", con);

            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                UserTypeDetails ud = new UserTypeDetails();
                ud.UserTypeId = (int)dr["UserTypeId"];
                ud.UserType = (string)dr["UserType"];
                list.Add(ud);
            }
            dr.Close();
            con.Close();
            return list;
        }
        public UserDetails CheckUserLogin(UserDetails ud)
        {
            UserDetails u = new UserDetails();
            SqlConnection con = new SqlConnection("Data Source=PRASHISH\\SQLEXPRESS;Integrated Security=true; Database=BroadwayDB");
            SqlCommand cmd = new SqlCommand("select * from tblUser where Username=@a and Password=@b", con);
            cmd.Parameters.AddWithValue("@a", ud.Username);
            cmd.Parameters.AddWithValue("@b", ud.Password);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                u.UserId = (int)dr["UserId"];
                u.Username = (string)dr["Username"];
                u.Password = (string)dr["sPassword"];
                u.UserTypeId = (int)dr["Usertype"];

            }
            dr.Close();
            con.Close();

            return u;
        }
        //public UserDetails CheckUserLogin(UserDetails ud)
        //{
        //    UserDetails u = new UserDetails();
        //    SqlConnection con = new SqlConnection("Data Source=PRASHISH\\SQLEXPRESS;Integrated Security=true; Database=BroadwayDB");
        //    SqlCommand cmd = new SqlCommand("select * from tblUser where Username=@a and Password=@b", con);
        //    cmd.Parameters.AddWithValue("@a", ud.Username);
        //    cmd.Parameters.AddWithValue("@b", ud.Password);
        //    SqlDataReader dr = null;
        //    con.Open();
        //    dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        u.UserId = (int)dr["UserId"];
        //        u.Username = (string)dr["Username"];
        //        u.Password = (string)dr["sPassword"];
        //        u.UserTypeId = (int)dr["Usertype"];

        //    }
        //    dr.Close();
        //    con.Close();
            
        //    return u;
        //}
    }
}
