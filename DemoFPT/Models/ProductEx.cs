using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoFPT.Models
{
    public class ProductEx : ProductAbstract
    {
        public override void Delete(int id)
        {
            using (var db = new DemoFPTEntities())
            {
                var product = db.Products.SingleOrDefault(x => x.Id == id);
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        public override void Insert(Product product)
        {
            using (var db = new DemoFPTEntities())
            {
                product.CreatedAt = DateTime.Now;
                product.UpdateAt = DateTime.Now;
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public override void Update(Product product)
        {
            using (var db = new DemoFPTEntities())
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
            }
        }
    }
}