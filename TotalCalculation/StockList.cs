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
    public partial class StockList : Form
    {
        public StockList()
        {
            InitializeComponent();
        }
        BLLStock bls = new BLLStock();
        int i = 0;
        private void StockList_Load(object sender, EventArgs e)
        {
            List<StockDetails> stock = bls.GetAllStocks();
            foreach (StockDetails item in stock)
            {
                dataGridView.Rows.Add();
                dataGridView.Rows[i].Cells["colStockId"].Value = item.StockId;
                dataGridView.Rows[i].Cells["colCategoryName"].Value = item.CategoryName;
                dataGridView.Rows[i].Cells["colProductName"].Value = item.ProductName;
                dataGridView.Rows[i].Cells["colQuantity"].Value = item.Quantity;
                i++;
            }
          
        }
    }
}
