using Listener.Filters;
using Listener.Models.AdminManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using PackageModule.Utilities;
using BusinessModels.AdminManagement;
using SoftLoggerAPI;

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



        [HttpGet]
        [Tokenizer]
        [Route("GetAgentProfile")]
        public HttpResponseMessage GetAgentProfile(string TokenID, string CompanyID)
        {
            string AdminProfileData = string.Empty;
            try
            {
                _logger.addMessage.Add("GetAgentProfile", "GetAgentProfile Method is goint to Execute");

                ManageAdminProfile objAdminProfile = new ManageAdminProfile();

                 AdminProfileData = objAdminProfile.GetAgentProfile(CompanyID,TokenID);


            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetAgentProfile", "Error During getting Agent Profile" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, AdminProfileData);
        }


        [HttpPost]
        [Tokenizer]
        [ModelValidator]
        [Route("UpdateAgentProfile")]
        public HttpResponseMessage UpdateAgentProfile(AgentProfile objAdminProfile)
        {
            bool status = false;
            try
            {
                _logger.addMessage.Add("GetAdminProfile", "GetAdminProfile Method is goint to Execute");

                ManageAdminProfile objManageAdminProfile = new ManageAdminProfile();

                status = objManageAdminProfile.UpdateAgentProfile(objAdminProfile);


            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetAdminProfile", "Error During getting Admin Profile" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, status);
        }


    }
}
