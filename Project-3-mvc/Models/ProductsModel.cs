using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_3_mvc.Models
{
    public class ProductsModel
    {
        public int ItemID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public HttpPostedFileBase ImgPath { get; set; }
    }
}