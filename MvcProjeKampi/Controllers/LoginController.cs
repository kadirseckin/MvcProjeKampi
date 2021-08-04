using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private AdminLoginManager adminLoginManager = new AdminLoginManager(new EfAdminDal());
        private WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            var admin=adminLoginManager.GetAdmin(p);
            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminUserName,false);
                Session["Admin"] = admin;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
               ModelState.AddModelError("", "Kullanıcı adı veya şifreniz hatalı.");
                return View();
            }
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            var writer = writerLoginManager.GetWriter(p);
            if (writer != null)
            {
                FormsAuthentication.SetAuthCookie(writer.WriterMail, false);
                Session["Writer"] = writer;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
               ModelState.AddModelError("", "Kullanıcı adı veya şifreniz hatalı.");
                return View();
            }

   
        }
    }
}