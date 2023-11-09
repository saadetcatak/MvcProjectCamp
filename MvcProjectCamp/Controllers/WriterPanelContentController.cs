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
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        Context context = new Context();
        public ActionResult MyContent(string p)
        {
           
            p = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();          
            var values = contentManager.TGetListByWriter(writeridinfo);
            return View(values);

        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
           ViewBag.d=id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content) 
        {
      
            content.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());

            string mail = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            content.WriterID = writeridinfo;

            content.ContentStatus = true;

            contentManager.TInsert(content);
            return RedirectToAction("MyContent");
            
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}