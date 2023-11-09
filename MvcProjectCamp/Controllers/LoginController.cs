using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
      

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Context context = new Context();
            var adminuser = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);

            if(adminuser!=null)
            {

                FormsAuthentication.SetAuthCookie(adminuser.UserName, false);
                Session["UserName"] = adminuser.UserName;
                return RedirectToAction("Index", "AdminCategory");

            }

            else
            {
                ViewBag.error = "Kullanıcı Adınız veya Şifreniz Hatalı, Tekrar Deneyin.";
                return RedirectToAction("Index");

            }

            return View();
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            Context context = new Context();
            var writeruser = context.Writers.FirstOrDefault(x => x.WriterMail== writer.WriterMail && x.WriterPassword == writer.WriterPassword);

            if (writeruser != null)
            {

                FormsAuthentication.SetAuthCookie(writeruser.WriterMail, false);
                Session["WriterMail"] = writeruser.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");

            }

            else
            {
                ViewBag.error = "Kullanıcı Adınız veya Şifreniz Hatalı, Tekrar Deneyin.";
                return RedirectToAction("WriterLogin","Login");

            }

            
            return View();
        }
    }
}