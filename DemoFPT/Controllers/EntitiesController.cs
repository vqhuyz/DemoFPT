using DemoFPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoFPT.Controllers
{
    public class EntitiesController : Controller
    {
        DemoFPTEntities db = new DemoFPTEntities();
        public ActionResult Index()
        {
            var list = db.Products.ToList();
            return View(list);
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            var product = db.Products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.SingleOrDefault(x => x.Id == id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.SingleOrDefault(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Insert(Product product)
        {
            product.CreatedAt = DateTime.Now;
            product.UpdateAt = DateTime.Now;
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            var _product = db.Products.Find(product.Id);
            _product.Name = product.Name;
            _product.Manufacture = product.Manufacture;
            _product.CreatedBy = product.CreatedBy;
            _product.UpdateAt = DateTime.Now;
            _product.UpdateBy = product.UpdateBy;
            _product.Deleted = product.Deleted;
            _product.Active = product.Active;
            _product.Description = product.Description;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}