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
        public ActionResult Index(string Sort)
        {
            using (var db = new DemoFPTEntities())
            {
                var list = db.Products.ToList();
                //ViewBag.Id = Sort == "id_decs" ? "id" : "id_decs";
                if (Sort == "id_desc")
                    ViewBag.Id = "id";
                else
                    ViewBag.Id = "id_desc";
                switch (Sort)
                {
                    case "id_desc":
                        list = list.OrderByDescending(x => x.Id).ToList();
                        break;
                    case "id":
                        list = list.OrderBy(x => x.Id).ToList();
                        break;
                    default:
                        list = list.OrderBy(x => x.Id).ToList();
                        break;
                }
                return View(list);
            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            ProductEx productEx = new ProductEx();
            var product = productEx.GetById(id);
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            ProductEx productEx = new ProductEx();
            productEx.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            ProductEx productEx = new ProductEx();
            var product = productEx.GetById(id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Insert(Product product)
        {
            ProductEx productEx = new ProductEx();
            productEx.Insert(product);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            ProductEx productEx = new ProductEx();
            productEx.Update(product);
            return RedirectToAction("Index");
        }
    }
}