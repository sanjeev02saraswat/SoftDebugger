using Newtonsoft.Json;
using PackageModule.Filters;
using PackageModule.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackageModule.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        const string RootLangPath = "~/LangConversion/PackageModule/Admin/Admin";
        // GET: Admin/Admin
        [Tokenizer]
        public ActionResult Index()
        {
            return View();
        }

       // [Tokenizer]
        public ActionResult CreateUser()
        {
            ViewBag.title = "Create New User";
            return View();
        }

        public ActionResult AddLocalization()
        {
            string LangConversion = string.Empty;
            string FileCulture = CommonFunction.GetFileCulture();
            
            //string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"" + RootLangPath + "/AddLocalization_" + FileCulture + ".json");
            //using (StreamReader r = new StreamReader(mapPath))
            //{
            //    LangConversion = r.ReadToEnd();
            //}
            ViewBag.AddLocalizationLangFile = JsonConvert.DeserializeObject(CommonFunction.GetResources("AddLocalization", FileCulture));
            ViewBag.title = "AddLocalization";
            return View();
        }
    }
}
