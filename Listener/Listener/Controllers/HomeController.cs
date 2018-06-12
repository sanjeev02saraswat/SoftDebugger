using Newtonsoft.Json;
using SoftLoggerAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Listener.Filters;
using WEBAPI2.Models;
using PackageModule.Utilities;
using BusinessModels.AdminManagement;
using Listener.Models.AdminManagement;
using BusinessModels.PackageBusinessModel;
using Listener.Models.PackageModel;

namespace WEBAPI2.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Home")]
    public class HomeController : ApiController
    {
        private readonly PackageListAutoComplete _objPackageListAutoComplete;
        private AsyncLogger _logger = null;
        public HomeController() : this(new PackageListAutoComplete())
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.HomeController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }
        public HomeController(PackageListAutoComplete objPackageListAutoComplete)
        {
            
            _objPackageListAutoComplete = objPackageListAutoComplete;
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

        [HttpPost]
        [Tokenizer]
        [Route("UpdateCompanyDetails")]
        public HttpResponseMessage UpdateCompanyDetails(CompanyDetails objCompanyDetails)
        {
            try
            {
                _logger.addMessage.Add("UpdateCompanyDetails", "UpdateCompanyDetails Method is goint to Execute");
                ManageCompanyProfile objManageCompanyProfile = new ManageCompanyProfile();
                bool status = objManageCompanyProfile.UpdateCompanyDetails(objCompanyDetails);
                if (status)
                {
                    return CommonUtility.CreateResponse(HttpStatusCode.OK, null);
                }
                else { return CommonUtility.CreateResponse(HttpStatusCode.InternalServerError, null); }

            }
            catch (System.Exception ex)
            {

                _logger.addMessage.Add("UpdateCompanyDetails", "Error during UpdateCompanyDetails Method Execution:" + ex.ToString());
                return CommonUtility.CreateResponse(HttpStatusCode.InternalServerError, null);
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }

        }

        [HttpGet]
        [Tokenizer]
        [Route("GetCompanyDetails")]
        public HttpResponseMessage GetCompanyDetails(string CompanyID,string TokenID)
        {
            try
            {
                _logger.addMessage.Add("GetCompanyDetails", "GetCompanyDetails Method is goint to Execute");
                ManageCompanyProfile objManageCompanyProfile = new ManageCompanyProfile();
                string CompanyDetails = objManageCompanyProfile.GetCompanyDetails(CompanyID, TokenID);

                return CommonUtility.CreateResponse(HttpStatusCode.OK, CompanyDetails);
            }
            catch (System.Exception ex)
            {

                _logger.addMessage.Add("UpdateCompanyDetails", "Error during UpdateCompanyDetails Method Execution:" + ex.ToString());
                return CommonUtility.CreateResponse(HttpStatusCode.InternalServerError, null);
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }

        }

        [HttpGet]
       // [Tokenizer]
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

        [HttpGet]
        [Tokenizer]
        [Route("GetCurrency")]
        public HttpResponseMessage GetCurrency()
        {

            string CurrencyConversion = "";
            string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/Currency.json");
            using (StreamReader r = new StreamReader(mapPath))
            {
                CurrencyConversion = r.ReadToEnd();
            }
            List<CurrencyList> objAllList = JsonConvert.DeserializeObject<List<CurrencyList>>(CurrencyConversion);
            return CommonUtility.CreateResponse(HttpStatusCode.OK, objAllList);
        }

        [HttpGet]
        [Tokenizer]
        [Route("GetCountry")]
        public HttpResponseMessage GetCountry()
        {

            string CountryList = "";
            string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/Country.json");
            using (StreamReader r = new StreamReader(mapPath))
            {
                CountryList = r.ReadToEnd();
            }
            List<CountryList> objAllList = JsonConvert.DeserializeObject<List<CountryList>>(CountryList);
            return CommonUtility.CreateResponse(HttpStatusCode.OK, objAllList);
        }

        [HttpPost]
        [Tokenizer]
        [Route("GetAirports")]
        public HttpResponseMessage GetAirports(AirportList objAirportList)
        {
            string JSONResult = "";
            try
            {
                _logger.addMessage.Add("GetAirports", "GetAirports Method is goint to Execute");
                JSONResult = _objPackageListAutoComplete.GetAirportList(objAirportList);
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetAirports", "Error during GetAirports  Method Execution:" + ex.ToString());
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, JSONResult);
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
                objSignupuser = objTokenManagement.CreateTokenforAgent(objSignupuser, Token);
                if (objSignupuser.LoginStatus)
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
        public HttpResponseMessage ValidateToken(string TokenID,string CompanyID)
        {
            //here we will check user is passing same token that we create for him
            bool Status = false;
            try
            {
                _logger.addMessage.Add("ValidateToken", "ValidateToken Method is goint to Execute");
                TokenManagement objTokenManagement = new TokenManagement();
                Status = objTokenManagement.VALIDATETokenforAgent(TokenID, CompanyID);
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

