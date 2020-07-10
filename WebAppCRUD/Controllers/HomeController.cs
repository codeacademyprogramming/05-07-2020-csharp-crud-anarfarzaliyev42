using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppCRUD.Context;
using WebAppCRUD.Models;

namespace WebAppCRUD.Controllers
{
    public class HomeController : Controller
    {
        readonly ProductContext db = new ProductContext();
        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();

            return View(products);
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            else
            {
                return new HttpStatusCodeResult(400);
            }
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public ActionResult EditProduct(Product product)
        {
            
            if (ModelState.IsValid)
            {
                Product product_ = db.Products.FirstOrDefault(x => x.Id == product.Id);
                if (product_==null)
                {
                    return new HttpStatusCodeResult(404);
                }
                db.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
              
            return RedirectToAction("Index", "Home");
        }
     
        public ActionResult EditProduct(int id)
        {
            Product product = db.Products.FirstOrDefault(x=>x.Id==id);
            return View(product);
        }
        public ActionResult ShowProductDetails(int id )
        {
            Product product = db.Products.FirstOrDefault(x=>x.Id==id);
            return View(product);

        }
       
        public ActionResult DoYouAgreeToDelete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }
       
        public ActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                 db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}