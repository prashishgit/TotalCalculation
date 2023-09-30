using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLStock
    {
        public StockDetails GetStockByProductId(int productid)
        {
            StockDetails sd = new StockDetails();
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("select * from tblStock where ProductId=@a", con);
            cmd.Parameters.AddWithValue("@a", productid);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                sd.StockId = (int)dr["StockId"];
                sd.ProductId = (int)dr["ProductId"];
                sd.Quantity = (int)dr["Quantity"];
                
            }
            dr.Close();
            con.Close();
            return sd;
        }
        public int InsertStock(StockDetails sd)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("insert into tblStock values(@a,@b)", con);
            cmd.Parameters.AddWithValue("@a", sd.ProductId);
            cmd.Parameters.AddWithValue("@b", sd.Quantity);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            return i;
        }
        public int UpdateStock(StockDetails sd)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("update tblStock set Quantity=@b where ProductId=@a", con);
            cmd.Parameters.AddWithValue("@a", sd.ProductId);
            cmd.Parameters.AddWithValue("@b", sd.Quantity);
           


            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            return i;
        }
        public List<StockDetails> GetAllStocks()
        {
            List<StockDetails> list = new List<StockDetails>();
            SqlConnection con = new SqlConnection("Data Source=Prashish; Integrated Security=true; Database=InventoryManagementDB;");
            SqlCommand cmd = new SqlCommand("SELECT tblCategory.CategoryName, tblProduct.ProductName, tblStock.Quantity, tblStock.StockId  FROM tblCategory INNER JOIN tblProduct ON tblCategory.CategoryId = tblProduct.CategoryId INNER JOIN tblStock ON tblProduct.ProductId = tblStock.ProductId", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                StockDetails std = new StockDetails();

                std.StockId = (int)dr["StockId"];
                std.CategoryName = (string)dr["CategoryName"];
                std.ProductName = (string)dr["ProductName"];
                std.Quantity = (int)dr["Quantity"];
                
                list.Add(std);
            }
            dr.Close();
            con.Close();
            return list;

        }

    }
}
