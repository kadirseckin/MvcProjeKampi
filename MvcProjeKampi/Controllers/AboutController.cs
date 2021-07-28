using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        private AboutManager _aboutManager = new AboutManager(new EfAboutDal());

        // GET: About
        public ActionResult Index()
        {
            var aboutValues = _aboutManager.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            _aboutManager.AboutAddBL(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {

            var aboutValue=_aboutManager.GetByID(id);
            _aboutManager.AboutDelete(aboutValue);

            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();

        }
    }
}