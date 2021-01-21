using MVCStore.Domain.Core;
using MVCStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
       private StoreContext db;
       private ProductRepository productRepository;
       private CategoryRepository categoryRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new StoreContext(connectionString);
        }
        public IRepository<Product> Products
        {
            get
            {
                if (productRepository== null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }

        public IRepository<Category> Categories 
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(db);
                }
                return categoryRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
