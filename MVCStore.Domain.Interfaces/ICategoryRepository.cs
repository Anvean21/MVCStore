using MVCStore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Interfaces
{
    //Del
   public interface ICategoryRepository:IDisposable
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void Create(Category item);
        void Update(Category item);
        void Delete(int id);
        void Save();
    }
}
