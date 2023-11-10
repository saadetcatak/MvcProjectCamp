using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
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
        public ActionResult ContentByHeading(int id)
        {

            var values = contentManager.TGetListByWriter(id);
            return View(values);
        }
        
        Context context=new Context();
        public ActionResult GetAllContent(string p)
        {
            var values=from x in context.Contents select x;
            if(!string.IsNullOrEmpty(p)) 
            {
                values=values.Where(y=>y.ContentValue.Contains(p));
            }
            //var values=context.Contents.ToList();
            return View(values.ToList());
        }

        
    }
}