using MVCStore.Domain.Infrastructure;
using MVCStore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCStore.Controllers
{
    public class HomeController : Controller
    {
        EFUnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new EFUnitOfWork("DefaultConnection");
        }
        public ActionResult Index()
        {
            return View(unitOfWork.Products.GetAll());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            unitOfWork.Products.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}