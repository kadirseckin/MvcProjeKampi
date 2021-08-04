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
    public class WriterPanelMessageController : Controller
    {
        private MessageManager messageManager = new MessageManager(new EfMessageDal());
        private MessageValidator messageValidator = new MessageValidator();

        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            Writer writer = (Writer)Session["Writer"];
            var messageList = messageManager.GetListInbox(writer.WriterMail);
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            Writer writer = (Writer)Session["Writer"];
            var messageList = messageManager.GetListSendBox(writer.WriterMail);
            return View(messageList);
        }


        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetMessageDetails(int id)
        {
            var messageValue = messageManager.GetByID(id);
            return View(messageValue);
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
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();



        }

    }
}