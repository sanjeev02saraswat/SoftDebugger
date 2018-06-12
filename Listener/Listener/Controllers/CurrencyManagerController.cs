using CurrencyConvertor;
using PackageModule.Utilities;
using SoftLoggerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Listener.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("CurrencyManagerController")]
    public class CurrencyManagerController : ApiController
    {
        private AsyncLogger _logger = null;
        public CurrencyManagerController()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.CurrencyManagerController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }

        [HttpGet]
        [Route("GetROE")]
        public HttpResponseMessage GetROE(string BaseCurrency,string SupplierCurrency)
        {
            string ROE = "";
            try
            {
                _logger.addMessage.Add("GetROE", "GetROE Method is goint to Execute");
                ICurrencyManager objCurrencyManager = new CurrencyManager();
                string RoeRate=objCurrencyManager.GetRoeRate(BaseCurrency, SupplierCurrency);
                if (!string.IsNullOrEmpty(RoeRate))
                {
                    return CommonUtility.CreateResponse(HttpStatusCode.OK, RoeRate);
                }


            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetROE", "Error during GetROE  Method Execution:" + ex.ToString());
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, "NO ROE Rate Available");
        }



    }
}
