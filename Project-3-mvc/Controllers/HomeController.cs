using Project_3_mvc.Models;
using Project_3_mvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_3_mvc.Controllers
{
    public class HomeController : Controller
    {
        private LaptopsEntities _db;
        public HomeController()
        {
            _db = new LaptopsEntities();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ProductsList()
        {
            IEnumerable<ProductsViewModel> Productslist = (from item in _db.Laptops

                                                           select new ProductsViewModel()
                                                           {
                                                               ImgPath = item.ImgPath,
                                                               Name = item.Name,
                                                               Price = item.Price,
                                                               Brand = item.Brand,
                                                               itemID = item.itemID

                                                           }).ToList();
            return View(Productslist);

        }
        
      [HttpPost]
        public JsonResult ProductsList(ProductsViewModel pro)
        {
            Order order = new Order();
            var updateorder = _db.Orders.Where(x => x.itemID == pro.itemID).FirstOrDefault();

            if (updateorder != null)
            {

                updateorder.Quantity = updateorder.Quantity + 1;
                updateorder.TotalCost = updateorder.TotalCost + updateorder.TotalCost;
                _db.SaveChanges();

            }
            else {
                order.itemID = pro.itemID;
                order.Quantity = 1;
                order.TotalCost = pro.Price;
                _db.Orders.Add(order);
                _db.SaveChanges();


            }
            return Json(new { Success = true, Counter = _db.Orders.Count() }, JsonRequestBehavior.AllowGet);

        }
    
        public ActionResult Search()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult ProuductSearch(String Searching)
        {
            IEnumerable<ProductsViewModel> SearchResult = (from item in _db.Laptops
                                                           where item.Name.Contains(Searching)
                                                           || item.Brand.Contains(Searching)

                                                           select new ProductsViewModel()
                                                           {
                                                               ImgPath = item.ImgPath,
                                                               Name = item.Name,
                                                               Price = item.Price,
                                                               Brand = item.Brand,
                                                               itemID = item.itemID

                                                           }).ToList();
            return View(SearchResult);
        }
        /*
        [HttpPost]
        String ProdSearch*/

    }    
}