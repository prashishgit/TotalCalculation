using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLSelling
    {
        public int CreateSells(SellingDetails sed)
        {
           
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("insert into tblSelling values(@a,@c,@d,@e,@f,@g,@h)", con);
            cmd.Parameters.AddWithValue("@a", sed.InvoiceSellingId);
            cmd.Parameters.AddWithValue("@c", sed.CategoryId);
            cmd.Parameters.AddWithValue("@d", sed.ProductId);
            cmd.Parameters.AddWithValue("@e", sed.Quantity);
            cmd.Parameters.AddWithValue("@f", sed.SellingPrice);
            cmd.Parameters.AddWithValue("@g", sed.InvoiceDate);
            cmd.Parameters.AddWithValue("@h", sed.Total);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            return i;
        }
    }
}
