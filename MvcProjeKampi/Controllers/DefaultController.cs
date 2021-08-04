using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        private ContentManager contentManager = new ContentManager(new EfContentDal());

        // GET: Default
        public ActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }
        public PartialViewResult Index()
        {
            var contentlist = contentManager.GetList();
            return PartialView(contentlist);
        }
    }
}