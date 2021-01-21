using MVCStore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Infrastructure
{
   public class StoreDbInitializer: DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {
            Category category1 = new Category { Name = "Bags" };
            Category category2 = new Category { Name = "Dresses" };
            Category category3 = new Category { Name = "Phones" };
            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);

            Product product = new Product { Name = "Iphone X", Price = 499, Description = "Very usefull phone", Category = category3 };
            Product product2 = new Product { Name = "Skirt", Price = 49, Description = "Very usefull skirt", Category = category2 };
            Product product3 = new Product { Name = "LuiBag", Price = 199, Description = "Very usefull Bag", Category = category1 };

            db.Products.Add(product);
            db.Products.Add(product2);
            db.Products.Add(product3);

            db.SaveChanges();
            base.Seed(db);
        }
    }
}
