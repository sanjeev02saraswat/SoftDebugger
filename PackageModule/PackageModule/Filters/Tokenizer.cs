using PackageModule.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace PackageModule.Filters
{
    public class Tokenizer : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpCookie cookie = filterContext.HttpContext.Request.Cookies.Get("PackageModule");

            if (cookie != null)
            {
                string TokenServiceURl = WebConfigurationManager.AppSettings["ListenerUrl"].ToString();
                HttpContext.Current.Session["listenertoken"] = cookie.Values["listenertoken"].ToString();
                string Success = CommonFunction.HITAPI("", TokenServiceURl + "Home/ValidateToken?TokenID=" + cookie.Values["listenertoken"].ToString(), "Get");

                if (Convert.ToBoolean(Success))
                {

                }

            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult("Your token might expired.....");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
