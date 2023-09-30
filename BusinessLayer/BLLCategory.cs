using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLCategory
    {
        public int CreateCategory(CategoryDetails cat)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("insert into tblCategory values(@a)", con);
            cmd.Parameters.AddWithValue("@a", cat.CategoryName);


            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            return i;
        }
        public int UpdateCategory(CategoryDetails cat)
        {
            SqlConnection con = new SqlConnection("Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("update tblUser set CategoryName=@a where CategoryId=@e", con);
            cmd.Parameters.AddWithValue("@a", cat.CategoryName);
            cmd.Parameters.AddWithValue("@b", cat.CategoryId);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
        public int DeleteUser(int userId)
        {
            SqlConnection con = new SqlConnection("Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("delete from tblStudent where UserId=@a", con);
            cmd.Parameters.AddWithValue("@a", userId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
        public List<CategoryDetails> GetAllCategory()
        {
            List<CategoryDetails> list = new List<CategoryDetails>();
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("select * from tblCategory", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CategoryDetails cat = new CategoryDetails();
                cat.CategoryId = (int)dr["CategoryId"];
                cat.CategoryName = (string)dr["CategoryName"];

                list.Add(cat);
            }
            dr.Close();
            con.Close();
            return list;
        }
        //public CategoryDetails GetCategoryById(int categoryid)
        //{
        //    CategoryDetails ud = new CategoryDetails();
        //    SqlConnection con = new SqlConnection("Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
        //    SqlCommand cmd = new SqlCommand("select * from tblCategory where category=@f", con);
        //    cmd.Parameters.AddWithValue("@f", categoryid);
        //    SqlDataReader dr = null;
        //    con.Open();
        //    dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        >=
        //        ud.UserId = (int)dr["UserId"];
        //        ud.Username = (string)dr["Username"];
        //        ud.Password = (string)dr["Password"];
        //        ud.Usertype = (string)dr["Usertype"];
        //        ud.Fullname = (string)dr["Fullname"];

        //    }

        //    dr.Close();
        //    con.Close();
        //    return ud;
        //}
    }
}
