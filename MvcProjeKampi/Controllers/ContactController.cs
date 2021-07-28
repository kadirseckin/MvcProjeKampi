using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        private ContactManager contactManager = new ContactManager(new EfContactDal());
        private ContactValidator contactValidator = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetByID(id);

            return View(contactValues);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}