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
    [Authorize]
    public class MessageController : Controller
    {
        private MessageManager messageManager = new MessageManager(new EfMessageDal());
        private MessageValidator messageValidator = new MessageValidator();

        // GET: Message
       
        public ActionResult Inbox()
        {
            Admin admin = (Admin)Session["Admin"];

            var messageList = messageManager.GetListInbox(admin.AdminUserName);
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            Admin admin = (Admin)Session["Admin"];
            var messageList = messageManager.GetListSendBox(admin.AdminUserName);
            return View(messageList);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
               // sessiondan alacağız p.SenderMail
                p.MessageDate = DateTime.Now;
                messageManager.MessageAddBL(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

            
         
        }

        public ActionResult GetMessageDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            return View(messageValue);
        }
    }
}