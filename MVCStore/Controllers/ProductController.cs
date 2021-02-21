using MVCStore.Domain.Core;
using MVCStore.Domain.Infrastructure;
using MVCStore.Models;
using MVCStore.MvcHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStore.Controllers
{
    public class ProductController : Controller
    {
        EFUnitOfWork unitOfWork;

        public ProductController()
        {
            unitOfWork = new EFUnitOfWork("DefaultConnection");
        }
        public ActionResult List(string category,int page = 1)
        {
            int pageSize = 3;
            ProductListViewModel model = new ProductListViewModel
            {
                Products = unitOfWork.Products.GetAll()
                .Where(p => category == null || p.Category.Name.ToLower() == category.ToLower())
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = category == null ?
        unitOfWork.Products.GetAll().Count() :
        unitOfWork.Products.GetAll().Where(cat => cat.Category.Name == category).Count()
                },
                 CurrentCategory = category
            };
            return View(model);
            //return View(unitOfWork.Products.GetAll());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Product p = unitOfWork.Products.Get(id);
            SelectList categories = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");
            ViewBag.Categories = categories;
            if (p==null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            if (unitOfWork.Products.GetAll().Any(x => x.Name.ToLower() == product.Name.ToLower()))
            {
                SelectList categories = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");
                ViewBag.Categories = categories;
                ModelState.AddModelError("", $"Product Name {product.Name} already exist");
                return View(product);
            }
                unitOfWork.Products.Update(product);
                unitOfWork.Save();
                return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            unitOfWork.Products.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Create()
        {
            SelectList categories = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            if (unitOfWork.Products.GetAll().Any(x => x.Name.ToLower() == product.Name.ToLower()))
            {
                SelectList categories = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");
                ViewBag.Categories = categories;
                ModelState.AddModelError("", $"Product Name {product.Name} already exist");
                return View(product);
            }
            unitOfWork.Products.Create(product);
            unitOfWork.Save();
            return RedirectToAction("List");
          
        }
    }
}