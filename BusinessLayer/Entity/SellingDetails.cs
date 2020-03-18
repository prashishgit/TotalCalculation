using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class SellingDetails
    {
        public int SellingId { get; set; }
        public int InvoiceSellingId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal SellingPrice { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Total { get; set; }
    }
}
