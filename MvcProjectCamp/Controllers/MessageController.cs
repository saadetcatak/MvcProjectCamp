using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();

        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            messageManager.TInsert(message);
            return View();

        }
    }
}