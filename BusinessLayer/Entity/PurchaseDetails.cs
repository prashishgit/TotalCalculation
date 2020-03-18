using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entity
{
    public class PurchaseDetails
    {
        public int PurchaseId { get; set; }
     
        public int InvoiceId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
