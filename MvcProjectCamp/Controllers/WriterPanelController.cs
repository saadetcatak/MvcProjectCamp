using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading(string p)
        {

            p = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.TGetListByWriter(writeridinfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {


            List<SelectListItem> valuecategory = (from x in categoryManager.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;

            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writeridinfo;
            heading.HStatus = true;
            headingManager.TInsert(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;
            var value = headingManager.TGetByID(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.TUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var value = headingManager.TGetByID(id);
            value.HStatus = false;
            headingManager.TDelete(value);
            return RedirectToAction("MyHeading");
        }
    }
}