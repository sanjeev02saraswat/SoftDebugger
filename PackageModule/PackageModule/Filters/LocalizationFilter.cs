using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SoftdebuggerWebsite.Filters
{
    public class Languages
    {
        public string LanguageCode { get; set; }

        public  string CultureCode { get; set; }
        public CultureInfo GlobalCultureInfo { get; set; }
    }
    public class LocalizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Languages objWrapper = new Languages();
            var languageCulture = string.Empty;
            objWrapper.LanguageCode = (string)HttpContext.Current.Session["langCode"];
            // string CompanyCode = HttpContext.Current.Request.QueryString.ToString();
            //objWrapp.IntializeToObjectWrapper();
            // = (Wrapper)(HttpContext.Current.Session["ObjectWrapper"]);
            HttpContextBase context = filterContext.HttpContext;
            string lang = "GB";
            if (objWrapper.LanguageCode != null && objWrapper.LanguageCode.ToString().ToUpperInvariant() != "UNDEFINED")
            {
                lang = objWrapper.LanguageCode;
            }
            else
            {
                lang = WebConfigurationManager.AppSettings["LangCode"].ToString();
            }
            //logCollection["LangCode"] = lang;
            filterContext.HttpContext.Session.Add("Lang", lang);
            if (lang.ToUpperInvariant()== "FR" || lang.ToUpperInvariant()=="FR-FR")
            {
                languageCulture = "fr-FR";
            }else if (lang.ToUpperInvariant()=="ES")
            {
                languageCulture = "es-ES";

            }else { languageCulture = "en-US"; }

            objWrapper.CultureCode = languageCulture;
            languageCulture = lang;
            
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(languageCulture);
            filterContext.RouteData.Values["lang"] = languageCulture;
            objWrapper.GlobalCultureInfo = new System.Globalization.CultureInfo(languageCulture);
            objWrapper.LanguageCode = lang;
            HttpContext.Current.Session["objWrapper"] = objWrapper;


            base.OnActionExecuting(filterContext);
        }
    }


    public class AjaxChildActionOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest() || controllerContext.IsChildAction;
        }
    }
}
