using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLUserType
    {
        public List<UserTypeDetails> GetAllUserType()
        {
            List<UserTypeDetails> list = new List<UserTypeDetails>();
            SqlConnection con = new SqlConnection("Data Source=PRASHISH\\SQLEXPRESS; Integrated Security=true; Database=BroadwayDB;");
            SqlCommand cmd = new SqlCommand("SELECT tblUser.UserId, tblUser.Username, tblUser.Password, tblUserType.UserType FROM tblUser INNER JOIN tblUserType ON tblUser.UsertypeId = tblUserType.UserTypeId");
            SqlDataReader dr = null;
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
    }
}
