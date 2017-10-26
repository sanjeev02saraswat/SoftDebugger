
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;
using SoftdebuggerWebsite.BusinessModels;
using SoftdebuggerWebsite.Models;
using SoftdebuggerWebsite.Filters;

namespace SoftdebuggerWebsite.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        // GET: Home
        [ActionName("Index")]
        public ActionResult Index()
        {
            string LangConversion = string.Empty;
            string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/LangConversion/SoftDebugger/Header/Header_en-US.json");
            using (StreamReader r = new StreamReader(mapPath))
            {
                LangConversion = r.ReadToEnd();
            }
          
            Session["LangFile"] = JsonConvert.DeserializeObject(LangConversion);
             mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/LangConversion/SoftDebugger/Index/Index_en-US.json");
            using (StreamReader r = new StreamReader(mapPath))
            {
                LangConversion = r.ReadToEnd();
            }
            ViewBag.IndexLangFile= JsonConvert.DeserializeObject(LangConversion);
            return View();
        }
        [ActionName("contact")]    
        [Route("~/contact")]  
        public ActionResult Contactus()
        {
            if (Session["LangFile"] ==null)
            {
                string LangConversion = string.Empty;
                string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/LangConversion/SoftDebugger/Header/Header_en-US.json");
                using (StreamReader r = new StreamReader(mapPath))
                {
                    LangConversion = r.ReadToEnd();
                }

                Session["LangFile"] = JsonConvert.DeserializeObject(LangConversion);

            }
            return View("~/Views/Home/Contactus.cshtml");
        }

        [AjaxChildActionOnlyAttribute]
        public void InsertCustomerEnquiry(ContactUsEnquiry objContactUsEnquiry)
        {
            CUSTOMER_ENQUIRY objCUSTOMER_ENQUIRY = new CUSTOMER_ENQUIRY();
            objCUSTOMER_ENQUIRY.InsertCustomerEnquiry(objContactUsEnquiry);

        }
       
    }
}