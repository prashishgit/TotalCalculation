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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
        }
        BLLCategory bc = new BLLCategory();
        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            CategoryDetails cat = new CategoryDetails();
            cat.CategoryName = txtCategory.Text;

            int i = bc.CreateCategory(cat);
            if (i > 0)
            {

                MessageBox.Show("Category Created");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
