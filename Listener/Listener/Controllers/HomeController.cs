using Newtonsoft.Json;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WEBAPI2.Filters;
using WEBAPI2.Models;
using WEBAPI2.Utilities;

namespace WEBAPI2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Home")]
    public class HomeController : ApiController
    {
        private AsyncLogger _logger = null;
        public HomeController()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.HomeController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }

        [HttpPost]
        //[Tokenizer]
        [Route("PostSignupuser")]
        public HttpResponseMessage PostSignupuser(Signupuser objSignupuser)
        {
            try
            {
                var session = HttpContext.Current.Session;
                if (session != null)
                {
                    if (session["Time"] == null)
                        session["Time"] = DateTime.Now;
                    objSignupuser.FirstName = "Session Time: " + session["Time"];
                }
                _logger.addMessage.Add("PostSignupuser", "PostSignupuser Method is goint to Execute");
                SignUpUserModel objSignUpUsermodel = new SignUpUserModel();
                objSignUpUsermodel.Registeruser(objSignupuser);
                return CommonUtility.CreateResponse(HttpStatusCode.OK, "Dear " + objSignupuser.FirstName + ", You have successfully sign up with SOftDebugger...");
            }
            catch (System.Exception ex)
            {

                _logger.addMessage.Add("PostSignupuser", "Error during Registeruser Method Execution:" + ex.ToString());
                return CommonUtility.CreateResponse(HttpStatusCode.InternalServerError, null);
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }

        }


        [HttpGet]
        [Route("GetLanguages")]
        public HttpResponseMessage GetLanguages()
        {
           
            string LangConversion = "";
            string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/Language.json");
            using (StreamReader r = new StreamReader(mapPath))
            {
                LangConversion = r.ReadToEnd();
            }
            List<LanguageList> objAllList = JsonConvert.DeserializeObject<List<LanguageList>>(LangConversion);
            return CommonUtility.CreateResponse(HttpStatusCode.OK, objAllList);
        }





        [HttpPost]
        [Route("Loginuser")]
        public HttpResponseMessage Loginuser(Signupuser objSignupuser)
        {
            try
            {
                _logger.addMessage.Add("Loginuser", "Loginuser Method is goint to Execute");
               
                    string Token = Guid.NewGuid().ToString();
                //will save same token against the user
                TokenManagement objTokenManagement = new TokenManagement();
                bool status = objTokenManagement.CreateTokenforAgent(objSignupuser,Token);
                if (status)
                {
                    objSignupuser.Tokenid = Token;
                }
                    return CommonUtility.CreateResponse(HttpStatusCode.OK, objSignupuser);
               
            }
            catch (System.Exception ex)
            {

                _logger.addMessage.Add("Loginuser", "Error during Loginuser Method Execution:" + ex.ToString());
                return CommonUtility.CreateResponse(HttpStatusCode.InternalServerError, null);
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }

        }

        [HttpGet]
        [Route("ValidateToken")]
        public HttpResponseMessage ValidateToken(string TokenID)
        {
            //here we will check user is passing same token that we create for him
            bool Status = false;
            try
            {
                _logger.addMessage.Add("ValidateToken", "ValidateToken Method is goint to Execute");
                TokenManagement objTokenManagement = new TokenManagement();
                Status = objTokenManagement.ValidateToken(TokenID);
                if (Status)
                {

                    //will save same token against the user

                    return CommonUtility.CreateResponse(HttpStatusCode.OK, Status);
                }
                else
                {
                    _logger.addMessage.Add("Loginuser", "Login Failed Against Token ID:" + TokenID.ToString());
                    return CommonUtility.CreateResponse(HttpStatusCode.Unauthorized, Status);
                }

            }
            catch (System.Exception ex)
            {
                _logger.addMessage.Add("ValidateToken", "Error During Validate Token for Token ID" + TokenID);
                _logger.addMessage.Add("Loginuser", "Error during Loginuser Method Execution:" + ex.ToString());
                return CommonUtility.CreateResponse(HttpStatusCode.InternalServerError, Status);
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }


        }

    }
}

