using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SoftdebuggerWebsite.Filters
{
    public class LocalizationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
           // throw new NotImplementedException();
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