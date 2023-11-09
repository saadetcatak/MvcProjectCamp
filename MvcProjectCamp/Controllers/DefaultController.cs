using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings()
        {
            var headingList=headingManager.TGetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList=contentManager.TGetList().Where(x=>x.HeadingID==id).ToList();
            return PartialView(contentList);
        }
    }
}