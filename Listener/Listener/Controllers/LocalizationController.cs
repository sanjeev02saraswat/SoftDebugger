using BusinessModels.LocalizationModel;
using Listener.Models.LocalizationManagement;
using SoftLoggerAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Listener.Filters;
using PackageModule.Utilities;

namespace Listener.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Localization")]
    public class LocalizationController : ApiController
    {
        private AsyncLogger _logger = null;
        public LocalizationController()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.LocalizationController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }

        [HttpGet]
        [Tokenizer]
        [Route("GetApplications")]
        public HttpResponseMessage GetApplications(string CompanyID)
        {
            string ApplicationList = "";

            try
            {
                _logger.addMessage.Add("GetApplications", "GetApplications Method is goint to Execute");

                ManageLocalization objManageLocalization = new ManageLocalization();
                ApplicationList = objManageLocalization.GetApplications(CompanyID);

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetApplications", "Error During getting Applications" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, ApplicationList);
        }


        [HttpGet]
        [Tokenizer]
        [Route("GetPageList")]
        public HttpResponseMessage GetPageList(string CompanyID,string ApplicationID)
        {
            string PagesList = "";

            try
            {
                _logger.addMessage.Add("GetPageList", "GetPageList Method is goint to Execute");

                ManageLocalization objManageLocalization = new ManageLocalization();
                PagesList = objManageLocalization.GetPageList(CompanyID, ApplicationID);

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetPageList", "Error During  GetPageList" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, PagesList);
        }



        [Tokenizer]
        [Route("GetResourcesFile")]
        public HttpResponseMessage GetResourcesFile(string CompanyID, string ApplicationName,string PageName,string Culture)
        {
            string PagesList = "";

            try
            {
                _logger.addMessage.Add("GetPageList", "GetPageList Method is goint to Execute");

                ManageLocalization objManageLocalization = new ManageLocalization();
                PagesList = objManageLocalization.GetResourcesContent(CompanyID, ApplicationName,PageName,Culture);

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetPageList", "Error During  GetPageList" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, PagesList);
        }


        [Tokenizer]
        [Route("AddNewResource")]
        [HttpPost]
        public HttpResponseMessage AddNewResource(LocalizationModel objLocalizationModel)
        {

            bool status = false;
            try
            {
                _logger.addMessage.Add("AddNewResource", "AddNewResource Method is goint to Execute");

                ManageLocalization objManageLocalization = new ManageLocalization();
                 status = objManageLocalization.AddNewResourceKey(objLocalizationModel);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("AddNewResource", "Error During  AddNewResource" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, status);
        }

    }
}
