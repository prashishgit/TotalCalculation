using BusinessLayer;
using BusinessLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalCalculation
{
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
        }
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLInvoice blin = new BLLInvoice();
        BLLStock bls = new BLLStock();
        BLLSellingInvoice blinsell = new BLLSellingInvoice();
        BLLSelling blselling = new BLLSelling();
        BLLPurchase bp = new BLLPurchase();
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

        int categoryid = 0;



        int productid = 0;

        decimal unitprice = 0;
        decimal quantity = 0;
        decimal total = 0;



        private void Selling_Load(object sender, EventArgs e)
        {
            LoadCategory();

            LoadInvoice();
        }

        private void LoadInvoice()
        {
            txtInvoiceDate.Text = DateTime.Today.ToShortDateString();
            InvoiceSellingDetails insd = blinsell.GetMaxInvoice();
            if (insd.InvoiceNo != null)
            {
                string[] str = insd.InvoiceNo.Split('-');
                int maxno = Convert.ToInt32(str[1].ToString()) + 1;
                txtInvoiceNumber.Text = ("INVSE-" + maxno);
            }
            else
            {
                txtInvoiceNumber.Text = "INVSE-1";
            }
            cboProduct.Enabled = false;
            txtGrandTotal.Text = "0.00";
        }

        private void CboCategory_SelectedIndexChanged(object sender, EventArgs e)
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

        private void CboProduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex != 0)
            {
                productid = Convert.ToInt32(cboProduct.SelectedValue.ToString());
                ProductDetails pro = blpro.GetProductByProductId(productid);

                txtSellingPrice.Text = pro.SellingPrice.ToString();
            }
        }

        private void TxtQuantity_TextChanged_1(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Length > 0)
            {
                unitprice = Convert.ToDecimal(txtSellingPrice.Text);
                quantity = Convert.ToDecimal(txtQuantity.Text);
                total = unitprice * quantity;
                txtTotal.Text = total.ToString();
            }
            else
            {
                txtQuantity.Text = "";
            }
        }
        int i = 0;
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            SellingDetails sellingdDetails = new SellingDetails();
            sellingdDetails.CategoryId = Convert.ToInt32(cboCategory.SelectedIndex.ToString());
            sellingdDetails.ProductId = productid;
            sellingdDetails.Quantity = Convert.ToInt32(txtQuantity.Text);
            sellingdDetails.SellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
            sellingdDetails.Total = Convert.ToDecimal(txtTotal.Text);
            StockDetails std = bls.GetStockByProductId(sellingdDetails.ProductId);
            if (std.Quantity >= sellingdDetails.Quantity)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells["colCategoryId"].Value = cboCategory.SelectedValue.ToString();
                dataGridView.Rows[i].Cells["colProductId"].Value = cboProduct.SelectedValue.ToString();
                dataGridView.Rows[i].Cells["colCategoryName"].Value = cboCategory.Text;
                dataGridView.Rows[i].Cells["colProductName"].Value = cboProduct.Text;
                dataGridView.Rows[i].Cells["colQuantity"].Value = txtQuantity.Text;
                dataGridView.Rows[i].Cells["colSellingPrice"].Value = txtSellingPrice.Text;
                dataGridView.Rows[i].Cells["colTotal"].Value = txtTotal.Text;
                txtGrandTotal.Text = (Convert.ToDecimal(txtGrandTotal.Text) + Convert.ToDecimal(txtTotal.Text)).ToString();
                sellingdDetails.ProductId = std.ProductId;
                std.Quantity = std.Quantity - sellingdDetails.Quantity;
                bls.UpdateStock(std);
                i++;
            }
            else
            {
                int t = Convert.ToInt32(std.Quantity);
                int q = Convert.ToInt32(sellingdDetails.Quantity);
                MessageBox.Show("You have only " + t + " " + cboProduct.Text + " " + " stock. But have entered " + q);
            }
            cboProduct.Enabled = false;
            txtQuantity.Text = "";
            txtSellingPrice.Text = "";
        }
       private void BtnSave_Click(object sender, EventArgs e)
        {
            InvoiceSellingDetails insd = new InvoiceSellingDetails();
            insd.InvoiceNo = txtInvoiceNumber.Text;
            insd.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
            insd.CustomerId = customerid;
            insd.GrandTotal = Convert.ToDecimal(txtGrandTotal.Text);
            int k = blinsell.CreateSellingInvoice(insd);

            SellingDetails sellingDetails = new SellingDetails();
            for (int j = 0; j < dataGridView.Rows.Count; j++)
            {
                sellingDetails.InvoiceSellingId = k;
                sellingDetails.ProductId = Convert.ToInt32(dataGridView.Rows[j].Cells["colProductId"].Value.ToString());
                sellingDetails.CategoryId = Convert.ToInt32(dataGridView.Rows[j].Cells["colCategoryId"].Value.ToString());
                sellingDetails.Quantity = Convert.ToInt32(dataGridView.Rows[j].Cells["colQuantity"].Value.ToString());
                sellingDetails.SellingPrice = Convert.ToDecimal(dataGridView.Rows[j].Cells["colSellingPrice"].Value.ToString());
                sellingDetails.Total = Convert.ToDecimal(dataGridView.Rows[j].Cells["colTotal"].Value.ToString());
                sellingDetails.InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
                blselling.CreateSells(sellingDetails);
            }
           MessageBox.Show("Sells Done");
            dataGridView.Rows.Clear();
            i = 0;
            LoadInvoice();

        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in dataGridView.SelectedRows)
            {
                int colProductId = Convert.ToInt32(dr.Cells["colProductId"].Value.ToString());
                StockDetails std = bls.GetStockByProductId(colProductId);
                decimal totalRemove = Convert.ToInt32(dr.Cells["colTotal"].Value.ToString());
                int colQuantity = Convert.ToInt32(dr.Cells["colQuantity"].Value.ToString());

                dataGridView.Rows.Remove(dr);
                std.Quantity = colQuantity + std.Quantity;
                std.ProductId = colProductId;
                bls.UpdateStock(std);
                txtGrandTotal.Text = (Convert.ToDecimal(txtGrandTotal.Text) - totalRemove).ToString();
                i = i - 1;
            }
        }

      
    }
}
