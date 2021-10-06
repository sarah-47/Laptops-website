using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_3_mvc.Models
{
    public class OrdersModel
    {
        public int OrderID { get; set; }
        public decimal TotalCost { get; set; }
        public int Quantity { get; set; }
        public int ItemID { get; set; }
    }
}