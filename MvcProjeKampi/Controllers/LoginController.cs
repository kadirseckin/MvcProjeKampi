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
    public class LoginController : Controller
    {
        AdminLoginManager adminLoginManager = new AdminLoginManager(new EfAdminDal());
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
                Session["AdminUserName"] = admin.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifreniz hatalı.");
                return View();
            }
        }
    }
}