using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BLLInvoice
    {
        public InvoiceDetails GetMaxInvoice()
        {
            InvoiceDetails ind = new InvoiceDetails();
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("select top 1 InvoiceNo from tblInvoice order by InvoiceId desc", con);
            SqlDataReader dr = null;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                ind.InvoiceNo = (string)dr["InvoiceNo"];
           }
            dr.Close();
            con.Close();
            return ind;
        }
        public int CreateInvoice(InvoiceDetails ind)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Prashish;Integrated Security=true; Database=InventoryManagementDB");
            SqlCommand cmd = new SqlCommand("insert into tblInvoice values(@a,@b,@c,@d);SELECT SCOPE_IDENTITY();", con);
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
