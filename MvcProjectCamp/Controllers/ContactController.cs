using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var values = contactManager.TGetList();
            return View(values);
        }

        public ActionResult GetContactDetails(int id)
        {
            var values = contactManager.TGetByID(id);
            return View(values);
        }

        public PartialViewResult InboxPartial()
        {
            
            return PartialView();
        }
    }
}