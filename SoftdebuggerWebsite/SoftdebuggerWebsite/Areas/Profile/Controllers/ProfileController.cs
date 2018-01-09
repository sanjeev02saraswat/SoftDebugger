using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftdebuggerWebsite.Areas.Profile.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}