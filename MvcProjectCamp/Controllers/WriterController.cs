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
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        public ActionResult Index()
        {
            var values = writerManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddWiter()
        {         
            return View();
        }

        [HttpPost]
        public ActionResult AddWiter(Writer p)
        {
            WriterValidator writervalidator = new WriterValidator();
            ValidationResult results = writervalidator.Validate(p);

            if(results.IsValid)
            {
                writerManager.TInsert(p);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var values = writerManager.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer p)
        {
            ValidationResult results = writervalidator.Validate(p);

            if (results.IsValid)
            {
                writerManager.TUpdate(p);
                return RedirectToAction("Index");
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