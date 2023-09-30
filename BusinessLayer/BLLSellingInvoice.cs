using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLSellingInvoice
    {
        public InvoiceSellingDetails GetMaxInvoice()
        {
            InvoiceSellingDetails insd = new InvoiceSellingDetails();
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("select top 1 InvoiceNo from tblInvoiceSelling order by InvoiceSellingId desc", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                insd.InvoiceNo = (string)dr["InvoiceNo"];
            }
            dr.Close();
            con.Close();
            return insd;
        }
        public int CreateSellingInvoice(InvoiceSellingDetails ind)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("insert into tblInvoiceSelling values(@a,@b,@c,@d);SELECT SCOPE_IDENTITY();", con);
            cmd.Parameters.AddWithValue("@a", ind.CustomerId);
            cmd.Parameters.AddWithValue("@b", ind.InvoiceNo);
            cmd.Parameters.AddWithValue("@c", ind.InvoiceDate);
            cmd.Parameters.AddWithValue("@d", ind.GrandTotal);


            con.Open();
            int i = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            return i;
        }
    }
}
