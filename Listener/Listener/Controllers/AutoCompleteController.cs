using Listener.Models.PackageModel;
using PackageBusinessModel.Models;
using PackageModule.Utilities;
using SoftLoggerAPI;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Listener.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("AutoCompleteController")]
    public class AutoCompleteController : ApiController
    {
        private AsyncLogger _logger = null;
        public AutoCompleteController()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.PackageController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }

        [HttpPost]
        [Route("GetPackagesAutoComplete")]
        public HttpResponseMessage GetPackagesAutoComplete(PackageList objPackageList)
        {
            string JSONResult = "";
            try
            {
                _logger.addMessage.Add("GetPackages", "GetPackages Method is goint to Execute");
                PackageListAutoComplete objPackageListAutoComplete = new PackageListAutoComplete();

                JSONResult = objPackageListAutoComplete.GetPackageList(objPackageList);



            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetPackages", "Error during GetPackages  Method Execution:" + ex.ToString());
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, JSONResult);
        }
    }
}
