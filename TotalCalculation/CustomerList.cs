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
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }
        public int customerid = 0;
        public string customername = "";
        BLLCustomer blc = new BLLCustomer();
        private void dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            customerid = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value.ToString());
            customername = dataGridView.CurrentRow.Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            dataGridView.DataSource = blc.GetAllCustomers();
            //Customer cat = new Customer();
            //if (cat.ShowDialog() == DialogResult.OK)
            //{
            //    dataGridView.DataSource = blc.GetAllCustomers();
            //}
        }

        private void btnCreateCustomer_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.ShowDialog();
            
        }
    }
}
