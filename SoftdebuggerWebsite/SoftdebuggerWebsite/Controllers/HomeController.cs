﻿
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
        const string AssemblyName = "SoftDebuggerWebsite";
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
            string LangConversion = string.Empty;
            string mapPath = string.Empty;
            if (Session["LangFile"] ==null)
            {
                 mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/LangConversion/SoftDebugger/Header/Header_en-US.json");
                using (StreamReader r = new StreamReader(mapPath))
                {
                    LangConversion = r.ReadToEnd();
                }

                Session["LangFile"] = JsonConvert.DeserializeObject(LangConversion);
            }
            mapPath= System.Web.HttpContext.Current.Server.MapPath(@"~/LangConversion/SoftDebugger/Contactus/Contactus_en-US.json");

            using (StreamReader r = new StreamReader(mapPath))
            {
                LangConversion = r.ReadToEnd();
            }
            ViewBag.ContactusLangFile = JsonConvert.DeserializeObject(LangConversion);
            return View("~/Views/Home/Contactus.cshtml");
        }

        [AjaxChildActionOnlyAttribute]
        public void InsertCustomerEnquiry(ContactUsEnquiry objContactUsEnquiry)
        {
            try
            {
                SoftLogger.SoftLogger.WriteLogImmediate("One New Enquiry With Below Details: Name:"+objContactUsEnquiry.CustomerName+"Mobile:"+objContactUsEnquiry.CustomerMobile+"Email:"+objContactUsEnquiry.Email+"Message:"+objContactUsEnquiry.CustomerMessage, "Homecontroller", AssemblyName);
                CUSTOMER_ENQUIRY objCUSTOMER_ENQUIRY = new CUSTOMER_ENQUIRY();
                objCUSTOMER_ENQUIRY.InsertCustomerEnquiry(objContactUsEnquiry);
                SoftLogger.SoftLogger.WriteLogImmediate("Enquiry Submitted Successfully", "Homecontroller", AssemblyName);
            }
            catch (Exception ex)
            {
                SoftLogger.SoftLogger.WriteLogImmediate("Error During Insert Customer Enquiry:" + ex.ToString(), "Homecontroller", AssemblyName);
            }
          

        }
       
    }
}