using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentByHeading()
        {
            int id;
            id = 3;
            var values = contentManager.TGetListByWriter(id);
            return View(values);
        }

        
    }
}