using DemoFPT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using System.Data.SqlClient;
using System.Data;

namespace DemoFPT.Controllers
{
    public class DapperController : Controller
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = DemoFPT; Integrated Security = True";
        // GET: Dapper
        public ActionResult Index()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var list = connection.Query<Product>("sp_GetAll_Products",commandType: CommandType.StoredProcedure).ToList();
                return View(list);
            }
        }

        public ActionResult Insert()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var product = connection.QueryFirstOrDefault<Product>("sp_GetById_Product", new { Id = id},commandType: CommandType.StoredProcedure);
                return View(product);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var product = connection.QueryFirstOrDefault<Product>("sp_Delete_Product", new { Id = id }, commandType: CommandType.StoredProcedure);
                return RedirectToAction("Index");
            }
        }

        public ActionResult Details(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var product = connection.QueryFirstOrDefault<Product>("sp_GetById_Product", new { Id = id }, commandType: CommandType.StoredProcedure);
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Insert(Product product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var insert = connection.Execute("sp_Create_Product",
                    new[]
                    {
                        new{product.Name, product.Manufacture, product.CreatedBy, product.Active,
                                product.Description, DateTime.Now},
                    },
                            commandType: CommandType.StoredProcedure
                    );
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var insert = connection.Execute("sp_Update_Product",
                    new[]
                    {
                        new{product.Id, product.Name, product.Manufacture, product.CreatedBy, product.Active,
                                product.Description, DateTime.Now, product.UpdateBy, product.Deleted},
                    },
                            commandType: CommandType.StoredProcedure
                    );
            }
            return RedirectToAction("Index");
        }
    }
}