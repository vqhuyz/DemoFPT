using DemoFPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoFPT.Controllers
{
    public class StoredController : Controller
    {
        // GET: Stored
        DemoFPTEntities db = new DemoFPTEntities();
        public ActionResult Index()
        {
            var list = db.Products.SqlQuery("sp_GetAll_Products").ToList();
            return View(list);
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            //var product = db.sp_GetById_Product(id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            db.sp_Delete_Product(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
           // var product = db.sp_GetById_Product(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Insert(Product product)
        {
            db.sp_Insert_Product(product.Name, product.Manufacture, product.CreatedBy, product.Active, 
                                product.Description, DateTime.Now);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            db.sp_Update_Product(product.Id, product.Name, product.Manufacture, product.CreatedBy, product.Active,
                                product.Description, DateTime.Now, product.UpdateBy, product.Deleted);
            return RedirectToAction("Index");
        }
    }
}