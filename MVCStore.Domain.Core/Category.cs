using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCStore.Domain.Core
{
   public class Category
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }

        public virtual ICollection<Product> Products{ get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }
}
