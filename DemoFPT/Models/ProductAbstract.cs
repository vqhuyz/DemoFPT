using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoFPT.Models
{
    public abstract class ProductAbstract
    {
        DemoFPTEntities db;
        public abstract void Insert(Product product);
        public abstract void Update(Product product);
        public abstract void Delete(int id);


        public virtual Product GetById(int id)
        {
            using (db = new DemoFPTEntities())
            {
                return db.Products.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}