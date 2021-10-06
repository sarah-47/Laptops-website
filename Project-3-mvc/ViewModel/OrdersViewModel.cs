using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_3_mvc.ViewModel
{
    public class OrdersViewModel
    {
        public int OrderID { get; set; }
        public decimal TotalCost { get; set; }
        public int Quantity { get; set; }
        public int ItemID { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public bool Confirmed { get; set; }
    }
}