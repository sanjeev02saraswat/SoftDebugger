using Newtonsoft.Json;
using PackageModule.Filters;
using PackageModule.Utility;
using SoftdebuggerWebsite.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackageModule.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private AsyncLogger _logger = null;
        const string RootLangPath = "~/LangConversion/PackageModule/Admin/Home";
        public HomeController()
        {

            _logger = new AsyncLogger();
            _logger.FileCollector = "PackageModule.Areas.Admin.Controllers";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }

        [LocalizationFilter]
        // GET: Admin/Home
        public ActionResult Index()
        {
            string LangConversion = string.Empty;
            string FileCulture = CommonFunction.GetFileCulture();          
                              
            return View();
        }

        [LocalizationFilter]
        //user can sign up or admin as well by default every admin will be considered as user ..Admin roles will be added internally
        public ActionResult SignUp()
        {
            Session["listenertoken"] = null;
            string LangConversion = string.Empty;
            string FileCulture = CommonFunction.GetFileCulture();
            _logger.addMessage.Add("ActionEntry", "Method is goint to Execute");
            
            string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"" + RootLangPath + "/SignUp_" + FileCulture + ".json");
            using (StreamReader r = new StreamReader(mapPath))
            {
                LangConversion = r.ReadToEnd();
            }
            ViewBag.SignUpLangFile = JsonConvert.DeserializeObject(LangConversion);
            AsyncLogger.LogMessage(_logger);
            return View();
        }

        [HttpGet]

        public bool CreateTokenCookie(string TokenID,string CompanyID,string AgentName,string LanguageCode)
        {
            HttpCookie myCookie = new HttpCookie("PackageModule");
            myCookie["listenertoken"] = TokenID;
            myCookie["Color"] = "Blue";
            myCookie.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(myCookie);
            Session["listenertoken"] = TokenID;
            Session["CompanyID"] = CompanyID;
            Session["AgentName"] = AgentName;
            Session["Localization"] = "en-US";
            Session["langCode"] = LanguageCode;
            return true;
           
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}
