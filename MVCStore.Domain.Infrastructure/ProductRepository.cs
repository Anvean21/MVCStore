using MVCStore.Domain.Core;
using MVCStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Infrastructure
{
    public class ProductRepository : IRepository<Product>
    {
        private StoreContext db;

        public ProductRepository(StoreContext context)
        {
            this.db = context;
        }
        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product!= null)
            {
                db.Products.Remove(product);
            }
        }

        public Product Get(int id)
        {
           return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Product item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
