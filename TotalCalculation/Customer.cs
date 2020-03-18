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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        BLLCustomer blc = new BLLCustomer();
        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerDetails cd = new CustomerDetails();
            cd.CustomerName = txtCustomerName.Text;
            cd.Email = txtEmail.Text;
            cd.Phone = txtPhone.Text;
            int i = blc.CreateCustomer(cd);
            if (i > 0)
            {

                MessageBox.Show("Category Created");
                this.DialogResult = DialogResult.OK;
            }
           
        }
    }
}
