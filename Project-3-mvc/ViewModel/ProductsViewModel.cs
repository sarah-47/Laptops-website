using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_3_mvc.ViewModel
{
    public class ProductsViewModel
    {
        public int itemID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string ImgPath { get; set; }
    }
}