using OracleFPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper.Oracle;
using System.Data;
using Dapper;
using Oracle.ManagedDataAccess.Client;
using OracleFPT.DI.Implements;
using OracleFPT.DI.Interface;

namespace OracleFPT.Controllers
{
    public class DapperController : Controller
    {
        private IDapperRepository _dapper = null;
        public DapperController(IDapperRepository dapper)
        {
            _dapper = dapper;
        }

        public ActionResult Index()
        {
            return View(_dapper.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            return View(_dapper.GetById(id));
        }

        public ActionResult Details(int id)
        {
            return View(_dapper.GetById(id));
        }

        public ActionResult Delete(int id)
        {
            _dapper.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Employees emp)
        {
            _dapper.Create(emp);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Employees emp)
        {
            _dapper.Update(emp);
            return RedirectToAction("Index");
        }
    }
}