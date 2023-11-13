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
    public class AuthorizationController : Controller
    {

        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var values = adminManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adminManager.TInsert(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            List<SelectListItem> role = (from x in adminManager.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.Role,
                                             Value = x.AdminID.ToString()
                                         }).ToList();
            ViewBag.role = role;

            var values = adminManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {

            adminManager.TUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var values = adminManager.TGetByID(id);
            if (values.AdminStatus == true)
            {
                values.AdminStatus = false;
            }
            else if (values.AdminStatus == false)
            {
                values.AdminStatus = true;
            }

            adminManager.TUpdate(values);

            return RedirectToAction("Index");
        }


    }
}
