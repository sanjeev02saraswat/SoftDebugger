using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Listener.Filters
{
   
    public class ModelValidator: ActionFilterAttribute
    {
        /// <summary>
        /// This Method will Validate the models if action contain any model data and in case of failure will return false to caller
        /// </summary>
        /// Written By:Sanjeev Saraswat(04-01-2018)
        /// <param name="actioncontext">Object of Http Request</param>
        public override void OnActionExecuting(HttpActionContext actioncontext)
        {
            if (actioncontext.ModelState.IsValid == false)
            {
                actioncontext.Response = actioncontext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actioncontext.ModelState);
            }

            base.OnActionExecuting(actioncontext);
        }
    }
}