using MVCStore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Interfaces
{
   public interface IUnitOfWork :IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }

        void Save();
    }
}
