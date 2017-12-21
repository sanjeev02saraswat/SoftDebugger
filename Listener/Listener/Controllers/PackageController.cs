using Listener.Models.PackageModel;
using PackageBusinessModel.Models;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WEBAPI2.Filters;
using WEBAPI2.Utilities;

namespace Listener.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Package")]
    public class PackageController : ApiController
    {
      
        private AsyncLogger _logger = null;
        public PackageController()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.PackageController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }

        [HttpPost]
        //[Tokenizer]
        [Route("CreateNewPackage")]
        public HttpResponseMessage CreatePackage(PackageDetails objPackageDetails)
        {
            try
            {
                _logger.addMessage.Add("CreatePackage", "CreatePackage Method is goint to Execute");
                CreatePackage objCreatePackage = new CreatePackage();

                objCreatePackage.AddPackage(objPackageDetails);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
              
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return null;
        }

        [HttpGet]
        //[Tokenizer]
        [Route("GetPackageCode")]
        public HttpResponseMessage GetPackageCode()
        {
            string PackageCode = "";


            try
            {
                _logger.addMessage.Add("GetPackageCode", "GetPackageCode Method is goint to Execute");
                PackageInfo objPackageInfo = new PackageInfo();
                 PackageCode = objPackageInfo.GetPackageCode();
                _logger.addMessage.Add("PackageCode", PackageCode);

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetPackageCode", "Error During getting Package Code"+ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, PackageCode);
        }
    }
}
