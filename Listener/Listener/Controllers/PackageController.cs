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
                CreatePackage objCreatePackage = new CreatePackage();

                objCreatePackage.AddPackage(objPackageDetails);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

            }
            return null;
        }

    }
}
