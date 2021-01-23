using MVCStore.Domain.Core;
using MVCStore.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStore.Controllers
{
    public class CategoryController : Controller
    {
        EFUnitOfWork unitOfWork;

        public CategoryController()
        {
            unitOfWork = new EFUnitOfWork("DefaultConnection");
        }

        public ActionResult CategoriesList()
        {
            return View(unitOfWork.Categories.GetAll());
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Category p = unitOfWork.Categories.Get(id);
            if (p == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Update(category);
                unitOfWork.Save();
                return RedirectToAction("CategoriesList");
            }
            return View(category);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            unitOfWork.Categories.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("CategoriesList");
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Categories.Create(category);
                unitOfWork.Save();
                return RedirectToAction("CategoriesList");
            }
            return View(category);
        }
    }
}