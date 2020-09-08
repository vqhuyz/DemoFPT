using DemoFPT_Oracle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoFPT_Oracle.Controllers
{
    public class EntitiesController : Controller
    {
        // GET: Entities
        public ActionResult Index()
        {
            using (var db = new DemoEntities())
            {
                var list = db.TBL_NHANVIEN.ToList();
                return View(list);
            }
        }
    }
}