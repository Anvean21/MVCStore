using MVCStore.Domain.Core;
using MVCStore.Domain.Infrastructure;
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
        public ActionResult List()
        {
            return View(unitOfWork.Products.GetAll());
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
            if (ModelState.IsValid)
            {
                unitOfWork.Products.Update(product);
                unitOfWork.Save();
                return RedirectToAction("List");
            }
            return View(product);
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
            if (ModelState.IsValid)
            {
                unitOfWork.Products.Create(product);
                unitOfWork.Save();
                return RedirectToAction("List");
            }
            return View(product);
        }
    }
}