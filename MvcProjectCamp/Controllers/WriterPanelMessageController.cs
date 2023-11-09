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

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var writermailinfo = writerManager.TGetList().Where(x => x.WriterMail == p).Select(x => x.WriterMail).FirstOrDefault();
            var values = messageManager.TGetList().OrderByDescending(x => x.MessageID).Where(x => x.ReceiverMail == writermailinfo).ToList();
            return View(values);
        }
        public ActionResult Sentbox()
        {
            string p = (string)Session["WriterMail"];
            var writermailinfo = writerManager.TGetList().Where(x => x.WriterMail == p).Select(x => x.WriterMail).FirstOrDefault();
            var values = messageManager.TGetList().OrderByDescending(x => x.MessageID).Where(x => x.SenderMail == writermailinfo).ToList();
            return View(values);
        }
        public PartialViewResult InboxPartial()
        {
            return PartialView();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.TGetByID(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = messageManager.TGetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = messageValidator.Validate(message);

            if (results.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                message.SenderMail = (string)Session["WriterMail"];
                messageManager.TInsert(message);
                return RedirectToAction("Sentbox");
            }

            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(message);
        }

    }
}