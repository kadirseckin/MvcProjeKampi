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
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        private ContentManager _contentManager = new ContentManager(new EfContentDal());

        public ActionResult MyContent()
        {
            Writer writer = (Writer)Session["Writer"];
           
            var contentValues = _contentManager.GetListByWriter(writer.WriterID);
            return View(contentValues);
        }

     
    }
}