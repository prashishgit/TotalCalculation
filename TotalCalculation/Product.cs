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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }
        BLLProduct blpro = new BLLProduct();
        BLLCategory bc = new BLLCategory();
        private void LoadGrid()
        {
            dataGridView.Rows.Clear();
            List<ProductDetails> list = blpro.GetAllProducts();
            int i = 0;
            foreach (ProductDetails item in list)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells[0].Value = item.ProductId;
                dataGridView.Rows[i].Cells[1].Value = item.CategoryName;
                dataGridView.Rows[i].Cells[2].Value = item.ProductName;
                dataGridView.Rows[i].Cells[3].Value = item.UnitPrice;
                dataGridView.Rows[i].Cells[4].Value = item.SellingPrice;
                i++;
            }

        }
        private void LoadCategory()
        {
            List<CategoryDetails> list = bc.GetAllCategory();
            CategoryDetails cd = new CategoryDetails();
            cd.CategoryName = "Choose Category";
            list.Insert(0, cd);
            cboCategory.DataSource = list;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
            cboCategory.SelectedIndex = 0;
        }
        private void btnCreateProduct_Click(object sender, EventArgs e)
        {
            
            ProductDetails pro = new ProductDetails();
            pro.CategoryId = Convert.ToInt32(cboCategory.SelectedValue.ToString());
            pro.ProductName = txtProductname.Text;
            pro.SellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
            pro.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            int i = blpro.CreateProduct(pro);
            if (i > 0)
            {

                MessageBox.Show("Product Created");
                this.DialogResult = DialogResult.OK;
            }
            
        }

        private void Product_Load(object sender, EventArgs e)
        {
            LoadGrid();
            LoadCategory();
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }
        int productid = 0;
        private void dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            productid = Convert.ToInt32(dataGridView.CurrentRow.Cells["colProductId"].Value.ToString());
            ProductDetails pro = blpro.GetProductById(productid);
            cboCategory.SelectedValue = pro.CategoryId;
            txtProductname.Text = pro.ProductName;
            txtSellingPrice.Text = pro.SellingPrice.ToString();
            txtUnitPrice.Text = pro.UnitPrice.ToString();
            btnCreateProduct.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ProductDetails pro = new ProductDetails();
            pro.ProductId = productid;
            pro.CategoryId = cboCategory.SelectedIndex;
            pro.ProductName = txtProductname.Text;
            pro.SellingPrice = Convert.ToDecimal(txtSellingPrice.Text);
            pro.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            int i = blpro.UpdateProduct(pro);
            if (i > 0)
            {
                LoadGrid();

                MessageBox.Show("Product Updated");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = blpro.DeleteProduct(productid);
            if (i > 0)
            {
                LoadGrid();
                txtProductname.Text = "";
                txtSellingPrice.Text = string.Empty;
                txtUnitPrice.Text = "";

                cboCategory.SelectedItem = "Choose Category";


                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                btnCreateProduct.Enabled = true;
                MessageBox.Show("Product Deleted");
            }
            else
            {
                MessageBox.Show(this, "Error");
            }
        }

       
    }
}
