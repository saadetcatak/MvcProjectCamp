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
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent(string p)
        {
            Context context = new Context();
            p = (string)Session["WriterMail"];
            var writeridinfo = context.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();          
            var values = contentManager.TGetListByWriter(writeridinfo);
            return View(values);

        }
    }
}