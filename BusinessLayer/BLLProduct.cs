using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLProduct
    {
        public int CreateProduct(ProductDetails pro)
        {
            SqlConnection con = new SqlConnection("Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("insert into tblProduct values(@a,@b,@c,@d)", con);
            cmd.Parameters.AddWithValue("@a", pro.CategoryId);
            cmd.Parameters.AddWithValue("@b", pro.ProductName);
            cmd.Parameters.AddWithValue("@c", pro.SellingPrice);
            cmd.Parameters.AddWithValue("@d", pro.UnitPrice);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public List<ProductDetails> GetAllProducts()
        {
            List<ProductDetails> list = new List<ProductDetails>();
            SqlConnection con = new SqlConnection("Data Source=Prashish; Integrated Security=true; Database=InventoryManagementDB;");
            SqlCommand cmd = new SqlCommand("SELECT tblCategory.CategoryName, tblProduct.ProductId, tblProduct.ProductName, tblProduct.SellingPrice, tblProduct.UnitPrice FROM tblCategory INNER JOIN tblProduct ON tblCategory.CategoryId = tblProduct.CategoryId", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductDetails pro = new ProductDetails();

                pro.ProductId = (int)dr["ProductId"];
                pro.CategoryName = (string)dr["CategoryName"];
                pro.ProductName = (string)dr["ProductName"];
                pro.SellingPrice = (decimal)dr["SellingPrice"];
                pro.UnitPrice = (decimal)dr["UnitPrice"];
                list.Add(pro);
            }
            dr.Close();
            con.Close();
            return list;

        }
        public ProductDetails GetProductById(int productid)
        {
            ProductDetails pro = new ProductDetails();
            SqlConnection con = new SqlConnection("Data Source=Prashish; Integrated Security=true; Database=InventoryManagementDB;");
            SqlCommand cmd = new SqlCommand("select * from tblProduct where ProductId=@a", con);
            cmd.Parameters.AddWithValue("@a", productid);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                pro.ProductId = (int)dr["ProductId"];
                pro.CategoryId = (int)dr["CategoryId"];
                pro.ProductName = (string)dr["ProductName"];
                pro.SellingPrice = (decimal)dr["SellingPrice"];
                pro.UnitPrice = (decimal)dr["UnitPrice"];
            }
            dr.Close();
            con.Close();
            return pro;

        }
        public List<ProductDetails> GetProductByCategoryId(int categoryid)
        {
            List<ProductDetails> list = new List<ProductDetails>();
            SqlConnection con = new SqlConnection("Data Source=Prashish; Integrated Security=true; Database=InventoryManagementDB;");
            SqlCommand cmd = new SqlCommand("select * from tblProduct where CategoryId=@a", con);
            cmd.Parameters.AddWithValue("@a", categoryid);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ProductDetails pro = new ProductDetails();
                pro.ProductId = (int)dr["ProductId"];
                pro.CategoryId = (int)dr["CategoryId"];
                pro.ProductName = (string)dr["ProductName"];
                pro.SellingPrice = (decimal)dr["SellingPrice"];
                pro.UnitPrice = (decimal)dr["UnitPrice"];
                list.Add(pro);
            }
            dr.Close();
            con.Close();
            return list;

        }
        public ProductDetails GetProductByProductId(int productid)
        {
            ProductDetails pro = new ProductDetails();
            SqlConnection con = new SqlConnection("Data Source=Prashish; Integrated Security=true; Database=InventoryManagementDB;");
            SqlCommand cmd = new SqlCommand("select * from tblProduct where ProductId=@a", con);
            cmd.Parameters.AddWithValue("@a", productid);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               
                pro.ProductId = (int)dr["ProductId"];
                pro.CategoryId = (int)dr["CategoryId"];
                pro.ProductName = (string)dr["ProductName"];
                pro.SellingPrice = (decimal)dr["SellingPrice"];
                pro.UnitPrice = (decimal)dr["UnitPrice"];
                
            }
            dr.Close();
            con.Close();
            return pro;

        }
        public int UpdateProduct(ProductDetails pro)
        {
            SqlConnection con = new SqlConnection("Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("update tblProduct set CategoryId=@a,ProductName=@b,SellingPrice=@c,UnitPrice=@d where ProductId=@e", con);
            cmd.Parameters.AddWithValue("@a", pro.CategoryId);
            cmd.Parameters.AddWithValue("@b", pro.ProductName);
            cmd.Parameters.AddWithValue("@c", pro.SellingPrice);
            cmd.Parameters.AddWithValue("@d", pro.UnitPrice);
            cmd.Parameters.AddWithValue("@e", pro.ProductId);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
        public int DeleteProduct(int productid)
        {
            SqlConnection con = new SqlConnection("Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("delete from tblProduct where ProductId=@a", con);
            cmd.Parameters.AddWithValue("@a", productid);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            return i;
        }
    

    }
}
