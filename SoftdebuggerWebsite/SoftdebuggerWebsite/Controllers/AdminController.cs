using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftdebuggerWebsite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }


        //Globalization Part

        public ActionResult Globalization()
        {
            return View();
        }

        public JsonResult GetApplicationName()
        {
            string s = "";
            return Json(s, JsonRequestBehavior.AllowGet);
        }
    }
}