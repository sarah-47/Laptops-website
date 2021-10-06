using Project_3_mvc.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_3_mvc.Controllers
{ 
    public class AdminController : Controller
    {
        private LaptopsEntities _db;
        public AdminController()
        {
            _db = new LaptopsEntities();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OredersList() {
            return View();
        }

        public ActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddItem(ProductsModel objProductsModel)
        {

            string NewImage = Guid.NewGuid() + Path.GetExtension(objProductsModel.ImgPath.FileName);
            objProductsModel.ImgPath.SaveAs(Server.MapPath("~/imgs/" + NewImage));

            Laptop laptop = new Laptop();
            laptop.ImgPath= "~/imgs/" + NewImage;
            laptop.Name = objProductsModel.Name;
            laptop.Price = objProductsModel.Price;
            laptop.Brand = objProductsModel.Brand;
            _db.Laptops.Add(laptop);
            _db.SaveChanges();

            return Json(new { Success = true, Message = "Item is added Successfully." }, JsonRequestBehavior.AllowGet);
        }
    }
}