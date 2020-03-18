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
    public partial class Try : Form
    {
        public Try()
        {
            InitializeComponent();
        }
        BLLCategory bc = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
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
        int i = 0;
        private void Try_Load(object sender, EventArgs e)
        {
            LoadCategory();
            cboProduct.Enabled = false;
            
           
           
        }
        int categoryid = 0;
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
        int productid = 0;
        private void CboProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex != 0)
            {
                productid = Convert.ToInt32(cboProduct.SelectedValue.ToString());
                ProductDetails pro = blpro.GetProductByProductId(productid);

                txtUnitPrice.Text = pro.UnitPrice.ToString();
                txtSellingPrice.Text = pro.SellingPrice.ToString();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
            dataGridView.Rows[i].Cells["colCategoryId"].Value = cboCategory.SelectedValue.ToString();
            dataGridView.Rows[i].Cells["colProductId"].Value = cboProduct.SelectedValue.ToString();
            dataGridView.Rows[i].Cells["colCategoryName"].Value = cboCategory.Text;
            dataGridView.Rows[i].Cells["colProductName"].Value = cboProduct.Text;
            dataGridView.Rows[i].Cells["colSellingPrice"].Value = txtSellingPrice.Text;
            dataGridView.Rows[i].Cells["colUnitPrice"].Value = txtUnitPrice.Text;
           
           
            i++;
            cboCategory.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
            cboProduct.Enabled = false;
            txtSellingPrice.Text = "";
        }
    }
}
