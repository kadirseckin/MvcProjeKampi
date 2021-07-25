using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        private WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var writerValues = writerManager.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p, HttpPostedFileBase profilePicture)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(p);

            if (validationResult.IsValid)
            {
                if (profilePicture != null &&
                    (profilePicture.ContentType == "image/jpeg" ||
                    profilePicture.ContentType == "image/jpg" ||
                    profilePicture.ContentType == "image/png"))
                {


                    string filename = $"pp_{Guid.NewGuid()}." +
                        $"{profilePicture.ContentType.Split('/')[1]}";

                    profilePicture.SaveAs(Server.MapPath($"~/Profile_Images/{filename}"));
                    p.WriterImage = filename;

                }
                else
                {
                    p.WriterImage = "default.png";
                }

                writerManager.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(p);
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {          
            var writerValue=writerManager.GetByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p, HttpPostedFileBase profilePicture)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult validationResult = writerValidator.Validate(p);

            if (validationResult.IsValid)
            {
                if (profilePicture != null &&
                   (profilePicture.ContentType == "image/jpeg" ||
                   profilePicture.ContentType == "image/jpg" ||
                   profilePicture.ContentType == "image/png"))
                {


                    string filename = $"pp_{Guid.NewGuid()}." +
                        $"{profilePicture.ContentType.Split('/')[1]}";

                    profilePicture.SaveAs(Server.MapPath($"~/Profile_Images/{filename}"));
                    p.WriterImage = filename;

                }

                writerManager.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(p);
        }

      
    }
}