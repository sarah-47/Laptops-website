using Project_3_mvc.Models;
using Project_3_mvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_3_mvc.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private LaptopsEntities _db;
        public CustomerController()
        {
            _db = new LaptopsEntities();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShopppingCart() {
    
           
            IEnumerable<OrdersViewModel> Cart = (from order in _db.Orders
                                                                     join
                                                                         item in _db.Laptops
                                                                         on order.itemID equals item.itemID
                                                                     select new OrdersViewModel()
                                                                     {
                                                                         ImgPath = item.ImgPath,
                                                                         Name = item.Name,
                                                                         Quantity = order.Quantity,
                                                                        TotalCost=order.TotalCost,
                                                                        OrderID=order.OrderID
                                                                     }

               ).ToList(); 

                       return View(Cart);

           
        }
        public ActionResult ShopppingCart2()
        {


            IEnumerable<OrdersViewModel> Cart = (from order in _db.Orders
                                                 join
                                                     item in _db.Laptops
                                                     on order.itemID equals item.itemID
                                                 select new OrdersViewModel()
                                                 {
                                                     ImgPath = item.ImgPath,
                                                     Name = item.Name,
                                                     Quantity = order.Quantity,
                                                     TotalCost = order.TotalCost,
                                                     OrderID = order.OrderID
                                                 }

               ).ToList();

            return View(Cart);


        }
        /*
        [HttpPost]
        public ActionResult ShopppingCart()
        {
          
                return RedirectToAction("ConfirmOrder");





        }*/
        [HttpPost]
        public ActionResult DeletProduct(int orderid) {
           
                var deletOrder= _db.Orders.FirstOrDefault(x => x.OrderID == orderid);
               
                    _db.Orders.Remove(deletOrder);
                    _db.SaveChanges();
            return RedirectToAction("ShopppingCart");


        }
        public ActionResult ConfirmOrder()
        {
            IEnumerable<OrdersViewModel> Order1 = (from order in _db.Orders
                                                 join
                                                     item in _db.Laptops
                                                     on order.itemID equals item.itemID
                                                 select new OrdersViewModel()
                                                 {
                                                     ImgPath = item.ImgPath,
                                                     Name = item.Name,
                                                     Quantity = order.Quantity,
                                                     TotalCost = order.TotalCost,
                                                     OrderID = order.OrderID
                                                 }

             ).ToList();
            return View(Order1);
        }
        public ActionResult UserData() {
            return View();
        }
    }
}