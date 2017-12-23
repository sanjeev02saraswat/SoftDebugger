using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WEBAPI2.Models;

namespace WEBAPI2.Filters
{
    public class Tokenizer : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actioncontext)
        {
            if (actioncontext.Request.Headers.Contains("tokenid") && actioncontext.Request.Headers.GetValues("tokenid") != null)
            {
                string TokenID = ((string[])(actioncontext.Request.Headers.GetValues("tokenid")))[0];
                string CompanyID= ((string[])(actioncontext.Request.Headers.GetValues("CompanyID")))[0];
                if (string.IsNullOrEmpty(TokenID) || string.IsNullOrEmpty(CompanyID))
                {
                    actioncontext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                }
                else
                {
                    TokenManagement objTokenManagement = new TokenManagement();
                    bool status = objTokenManagement.VALIDATETokenforAgent(TokenID,CompanyID);
                    if (!status)
                    {
                        actioncontext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

                    }
                }
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("You are not allowed to access this service with this format."),
                    ReasonPhrase = "Token might expired and you are missing to pass tokenid in header."
                };
                actioncontext.Response = response;


            }


            base.OnActionExecuting(actioncontext);
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                var type = objectContent.ObjectType; //type of the returned object
                var value = objectContent.Value; //holding the returned value
            }

            Debug.WriteLine("ACTION 1 DEBUG  OnActionExecuted Response " + actionExecutedContext.Response.StatusCode.ToString());
        }


    }
}
