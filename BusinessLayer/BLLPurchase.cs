using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLPurchase
    {
        public int CreatePurchase(PurchaseDetails pd)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("insert into tblPurchase values(@a,@c,@d,@e,@f,@g,@h)", con);
            cmd.Parameters.AddWithValue("@a", pd.InvoiceId);
            cmd.Parameters.AddWithValue("@c", pd.CategoryId);
            cmd.Parameters.AddWithValue("@d", pd.ProductId);
            cmd.Parameters.AddWithValue("@e", pd.Quantity);
            cmd.Parameters.AddWithValue("@f", pd.UnitPrice);
            cmd.Parameters.AddWithValue("@g", pd.Total);
            cmd.Parameters.AddWithValue("@h", pd.InvoiceDate);

            con.Open();
            int i = cmd.ExecuteNonQuery();

            con.Close();

            return i;
        }
    }
}
