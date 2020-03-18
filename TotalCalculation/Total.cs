using BusinessLayer;
using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCalculation
{
    public partial class Total : Form
    {
        public Total()
        {
            InitializeComponent();
        }

       
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLInvoice blin = new BLLInvoice();
        BLLStock bls = new BLLStock();
        BLLPurchase bp = new BLLPurchase();
        BLLLoginDetail blld = new BLLLoginDetail();
        int customerid = 0;
        private void txtCustomerName_MouseClick(object sender, MouseEventArgs e)
        {
            CustomerList customerlist = new CustomerList();
            if (customerlist.ShowDialog() == DialogResult.OK)
            {
                customerid = customerlist.customerid;
                txtCustomerName.Text = customerlist.customername;
            }
        }
        private void LoadCategory()
        {
            List<CategoryDetails> list = blcat.GetAllCategory();
            CategoryDetails cd = new CategoryDetails();
            cd.CategoryName = "Choose Category";
            list.Insert(0, cd);
            cboCategory.DataSource = list;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
            cboCategory.SelectedIndex = 0;
        }
        private void LoadProduct()
        {
            List<ProductDetails> list = blpro.GetAllProducts();
            ProductDetails pd = new ProductDetails();
            pd.CategoryName = "Choose Product";
            list.Insert(0, pd);
            cboProduct.DataSource = list;
            cboProduct.DisplayMember = "ProductName";
            cboProduct.ValueMember = "ProductId";
            cboProduct.SelectedIndex = 0;
        }
        private void Total_Load(object sender, EventArgs e)
        {
            
            LoadCategory();

            txtInvoiceDate.Text = DateTime.Today.ToShortDateString();
            InvoiceDetails ind = blin.GetMaxInvoice();
            if (ind.InvoiceNo != null)
            {
                string[] str = ind.InvoiceNo.Split('-');
                int maxno = Convert.ToInt32(str[1].ToString()) + 1;
                txtInvoiceNumber.Text = ("INV-" + maxno);
            }
            else
            {
                txtInvoiceNumber.Text = "INV-1";
            }
            cboProduct.Enabled = false;
            txtGrandTotal.Text = "0.00";
            btnAdd.Enabled = false;
        }
        int categoryid = 0;

        
        private void cboCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboCategory.SelectedIndex != 0)
            {
                categoryid = Convert.ToInt32(cboCategory.SelectedValue.ToString());
                List<ProductDetails> list = blpro.GetProductByCategoryId(categoryid);
                ProductDetails pd = new ProductDetails();
                cboProduct.Enabled = true;
                pd.ProductName = "Choose Product";
                list.Insert(0, pd);
                cboProduct.DataSource = list;
                cboProduct.DisplayMember = "ProductName";
                cboProduct.ValueMember = "ProductId";
                cboProduct.SelectedIndex = 0;
            }
        }
        int productid = 0;
        private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex != 0)
            {
                productid = Convert.ToInt32(cboProduct.SelectedValue.ToString());
                ProductDetails pro = blpro.GetProductByProductId(productid);

                txtUnitPrice.Text = pro.UnitPrice.ToString();
            }

        }
        decimal unitprice = 0;
        decimal quantity = 0;
        decimal total = 0;
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Length > 0)
            {
                unitprice = Convert.ToDecimal(txtUnitPrice.Text);
                quantity = Convert.ToDecimal(txtQuantity.Text);
                total = unitprice * quantity;
                txtTotal.Text = total.ToString();
                btnAdd.Enabled = true;
            }
            else
            {
                txtQuantity.Text = "";
                btnAdd.Enabled = false;
            }
        }
        int i = 0;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            dataGridView.Rows.Add();
            dataGridView.Rows[i].Cells["colCategoryId"].Value = cboCategory.SelectedValue.ToString();
            dataGridView.Rows[i].Cells["colProductId"].Value = cboProduct.SelectedValue.ToString();
            dataGridView.Rows[i].Cells["colCategoryName"].Value = cboCategory.Text;
            dataGridView.Rows[i].Cells["colProductName"].Value = cboProduct.Text;
            dataGridView.Rows[i].Cells["colQuantity"].Value = txtQuantity.Text;
            dataGridView.Rows[i].Cells["colUnitPrice"].Value = txtUnitPrice.Text;
            dataGridView.Rows[i].Cells["colTotal"].Value = txtTotal.Text;
            txtGrandTotal.Text = (Convert.ToDecimal(txtGrandTotal.Text) + Convert.ToDecimal(txtTotal.Text)).ToString();
            i++;
            cboCategory.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
            cboProduct.Enabled = false;
            txtQuantity.Text = "";
            txtUnitPrice.Text = "";
            txtTotal.Text = "";

        }
        

        private void btnCategory_Click(object sender, EventArgs e)
        {
            Category cat = new Category();
            if (cat.ShowDialog() == DialogResult.OK)
            {
                LoadCategory();
            }
        }

     
        private void btnProduct_Click(object sender, EventArgs e)
        {
            Product pro = new Product();
            if (pro.ShowDialog() == DialogResult.OK)
            {
                LoadProduct();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            InvoiceDetails ind = new InvoiceDetails();
            ind.InvoiceNo = txtInvoiceNumber.Text;
            ind.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            ind.CustomerId = customerid;
            ind.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
            int k = blin.CreateInvoice(ind);
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                PurchaseDetails pd = new PurchaseDetails();
                pd.InvoiceId = k;
                pd.ProductId = Convert.ToInt32(dataGridView.Rows[i].Cells["colProductId"].Value.ToString());
                pd.CategoryId = Convert.ToInt32(dataGridView.Rows[i].Cells["colCategoryId"].Value.ToString());
                pd.UnitPrice = Convert.ToDecimal(dataGridView.Rows[i].Cells["colUnitPrice"].Value.ToString());
                pd.Quantity = Convert.ToInt32(dataGridView.Rows[i].Cells["colQuantity"].Value.ToString());
                
                pd.Total = Convert.ToDecimal(dataGridView.Rows[i].Cells["colTotal"].Value.ToString());
                pd.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
                StockDetails sd = bls.GetStockByProductId(pd.ProductId);
                if (sd.Quantity >0)
                {
                    sd.ProductId = pd.ProductId;
                    
                    sd.Quantity = sd.Quantity + pd.Quantity;
                    int m = bls.UpdateStock(sd);
                }else if(sd.ProductId == pd.ProductId)
                {
                    sd.ProductId = pd.ProductId;

                    sd.Quantity = sd.Quantity + pd.Quantity;
                    int m = bls.UpdateStock(sd);
                }
                
                else
                {
                    StockDetails sds = new StockDetails();
                    sds.StockId = sd.StockId;
                    sds.ProductId = pd.ProductId;
                    sds.Quantity = pd.Quantity;
                    int l = bls.InsertStock(sds);
                }
                bp.CreatePurchase(pd);
               
            }
            MessageBox.Show("Purchase Done");
            dataGridView.Rows.Clear();
           
            i = 0;
           
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            LoginDetails ld = new LoginDetails();
            ld.LoginDetailId = Program.LoginDetailId;
            ld.UserId = Program.UserId;
            ld.LogoutTime = DateTime.Now.ToShortTimeString();
            string d = DateTime.Now.ToString("HH:mm:ss");
            TimeSpan ts = TimeSpan.Parse(d);
            double logoutTime = ts.TotalSeconds;
            double duration = logoutTime - Program.loginTime;
            TimeSpan time = TimeSpan.FromSeconds(duration);
            string str = time.ToString(@"hh\:mm\:ss");
            int o = blld.Logoutupdate(ld);
            if(o>0)
            {
                this.Hide();
                MessageBox.Show(Program.username+" you have been LogOut. You have been Logged in for "+ str + " seconds");
            }
            this.Close();
            //Login l = new Login();
            //l.Show();
        }

        private void BtnStock_Click(object sender, EventArgs e)
        {
            StockList sl = new StockList();
            sl.Show();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                // Set the printer name. 
                //pd.PrinterSettings.PrinterName = "\\NS5\hpoffice
                //pd.PrinterSettings.PrinterName = "Zebra New GK420t"               
                pd.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
        }
        void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            Font printFont = new Font("3 of 9 Barcode", 17);
            Font printFont1 = new Font("Times New Roman", 9, FontStyle.Bold);

            SolidBrush br = new SolidBrush(Color.Black);

            ev.Graphics.DrawString("*AAAAAAFFF*", printFont, br, 10, 65);
            ev.Graphics.DrawString("*AAAAAAFFF*", printFont1, br, 10, 85);
        }
    
    }
}
