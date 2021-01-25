using MVCStore.Domain.Core;
using MVCStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCStore.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}