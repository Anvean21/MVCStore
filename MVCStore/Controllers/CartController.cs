using MVCStore.Domain.Core;
using MVCStore.Domain.Infrastructure;
using MVCStore.Domain.Interfaces;
using MVCStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStore.Controllers
{
    public class CartController : Controller
    {
        EFUnitOfWork unitOfWork;
       
        public CartController()
        {
            unitOfWork = new EFUnitOfWork("DefaultConnection");
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = unitOfWork.Products.GetAll()
                .FirstOrDefault(g => g.Id == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
             return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = unitOfWork.Products.GetAll()
                .FirstOrDefault(g => g.Id == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            if (cart.Lines.Count() == 0)
            {
                return RedirectToAction("List", "Product");
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        //Этот метод больше не нужен, связыватель моделей делает всю работу.
        //public Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}