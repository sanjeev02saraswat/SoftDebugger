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
    [RoutePrefix("Admin")]
    public class AdminController : ApiController
    {
        private AsyncLogger _logger = null;
        public AdminController()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.AdminController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }


        [HttpGet]
        [Tokenizer]
        [Route("GetAdminAccess")]
        public HttpResponseMessage GetAdminAccess(string TokenID,string CompanyID)
        {
            try
            {
                _logger.addMessage.Add("GetAdminAccess", "GetAdminAccess Method is goint to Execute");
                

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetAdminAccess", "Error During getting Admin Access" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, null);
        }

    }
}
