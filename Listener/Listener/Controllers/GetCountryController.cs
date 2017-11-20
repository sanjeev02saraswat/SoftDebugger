using Newtonsoft.Json.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using WEBAPI2.Models;
using PackageModule.Filters;
using WEBAPI2.Utilities;

namespace WEBAPI2.Controllers
{


    [RoutePrefix("GetCountry")]
    public class GetCountryController : ApiController
    {
        private AsyncLogger _logger = null;

        public GetCountryController()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.GetCountryController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }

        [HttpGet]
        [Route("GetAllCountry")]
        public HttpResponseMessage GetCountryNames()
        {

            CountryList objIN = new CountryList();
            objIN.code = "IN";
            objIN.name = "India";
            objIN.dial_code = "+91";

            CountryList objUS = new CountryList();
            objUS.code = "US";
            objUS.name = "United States of America";
            objUS.dial_code = "+1";
            List<CountryList> objList = new List<CountryList>();
            objList.Add(objIN);
            objList.Add(objUS);

            return CommonUtility.CreateResponse(HttpStatusCode.OK, objList);
        }


        [HttpGet]
        [Route("GetAllCountryAutoComplete/{Prefix}")]
        public HttpResponseMessage GetCountryAutoComplete(string Prefix)
        {
            string LangConversion = "";
            string mapPath = System.Web.HttpContext.Current.Server.MapPath(@"~/Data/Country.json");
            using (StreamReader r = new StreamReader(mapPath))
            {
                LangConversion = r.ReadToEnd();
            }
            List<CountryList> objAllList = JsonConvert.DeserializeObject<List<CountryList>>(LangConversion);
            List<CountryList> objCountries = objAllList.Where(con => con.name.ToLowerInvariant().StartsWith(Prefix.ToLowerInvariant())).ToList();

            return CommonUtility.CreateResponse(HttpStatusCode.OK, objCountries);
        }

        [HttpPost]
        [Route("Signupuser")]
        public HttpResponseMessage PostSignupuser(Signupuser objSignupuser)
        {
            try
            {
                _logger.addMessage.Add("PostSignupuser", "PostSignupuser Method is goint to Execute");
                SignUpUserModel objSignUpUsermodel = new SignUpUserModel();
                objSignUpUsermodel.Registeruser(objSignupuser);

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
            return CommonUtility.CreateResponse(HttpStatusCode.OK, null);
        }

    }
}

