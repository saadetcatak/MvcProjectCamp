using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        Context context = new Context();
        public ActionResult Inbox()
        {
            var values = messageManager.TInboxList().OrderByDescending(x => x.MessageID).ToList();
            return View(values);
        }


        public ActionResult Sentbox()
        {
            var values = messageManager.TSentList().OrderByDescending(x => x.MessageID).ToList();
            return View(values);
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
                message.MessageDate = DateTime.Now;
                messageManager.TInsert(message);
                return RedirectToAction("Sentbox", "Message");
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

       
        public ActionResult GetAllMessage(string p)
        {
            var values = from x in context.Messages select x;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(y => y.ReceiverMail.Contains(p));
            }
            //var values=context.Contents.ToList();
            return View(values.ToList());
        }
    }

}