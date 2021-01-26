using MVCStore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCStore.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}