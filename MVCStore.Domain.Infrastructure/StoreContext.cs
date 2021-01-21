using MVCStore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Infrastructure
{
   public class StoreContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        static StoreContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }
        public StoreContext(string connectionString)
            :base(connectionString)
        {
        }
    }
}
