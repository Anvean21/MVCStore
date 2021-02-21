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
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = unitOfWork.Categories.GetAll()
                .Where(x => x.Products.Count() != 0)
                .Select(game => game.Name)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
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
            if (!ModelState.IsValid)
            {
                return View(category);
            }
                unitOfWork.Categories.Update(category);
                unitOfWork.Save();
                return RedirectToAction("CategoriesList");
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
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            if (unitOfWork.Categories.GetAll().Any(x => x.Name.ToLower() == category.Name.ToLower()))
            {
                ModelState.AddModelError("", $"Category *{category.Name}* already exist");
                return View(category);
            }

            unitOfWork.Categories.Create(category);
            unitOfWork.Save();
            return RedirectToAction("CategoriesList");
        }
    }
}