using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevExpress.Model
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Unit Price")]
        public string UnitPrice { get; set; }

        public decimal Total
        {
            get
            {
                return Qty * Price;
            }
        }

        public decimal GTGT 
        {
            get
            {
                return Decimal.Multiply(Total, 0.1M);
            }
        }

        public decimal ThueGTGT
        {
            get
            {
                return Decimal.Multiply(Total, 0.05M);
            }
        }

        public decimal TotalPlusTax
        {
            get
            {
                return Total + GTGT + ThueGTGT;
            }
        }
    }
}
