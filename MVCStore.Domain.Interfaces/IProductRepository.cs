using MVCStore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Interfaces
{
    //del
   public interface IProductRepository : IDisposable
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        void Create(Product item);
        void Update(Product item);
        void Delete(int id);
        void Save();
    }
}
