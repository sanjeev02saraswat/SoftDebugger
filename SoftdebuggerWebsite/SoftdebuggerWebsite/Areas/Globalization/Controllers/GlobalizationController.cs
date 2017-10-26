using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftdebuggerWebsite.Areas.Globalization.Controllers
{
    public class GlobalizationController : Controller
    {
        // GET: Globalization/Globalization
        //I have added this controller for Language handling ..I will handle this part.sanjeev Saraswat
        public ActionResult Index()
        {
            string LangConversion = string.Empty;
            string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/LangConversion/Globalization/Header/Header_en-US.json");
            using (StreamReader r = new StreamReader(mapPath))
            {
                LangConversion = r.ReadToEnd();
            }

            Session["LangFile"] = JsonConvert.DeserializeObject(LangConversion);
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AddUpdateResource()
        {
            return View();
        }
    }
}