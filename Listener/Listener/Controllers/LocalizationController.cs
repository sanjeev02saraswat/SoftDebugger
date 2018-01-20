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

        [HttpPost]
        [Tokenizer]
        [Route("GetExistingResource")]
        public HttpResponseMessage GetExistingResource(LocalizationModel objLocalizationModel)
        {
            LocalizationModel ResourceValueLocalization = null;
            try
            {
                _logger.addMessage.Add("GetExistingResource", "GetExistingResource Method is goint to Execute");

                ManageLocalization objManageLocalization = new ManageLocalization();
                 ResourceValueLocalization = objManageLocalization.GetExistingResourceValue(objLocalizationModel);
                if (string.IsNullOrEmpty(ResourceValueLocalization.ResourceValue))
                {
                    _logger.addMessage.Add("GetExistingResource", "No Resource Value Exist Against Resource Key: "+ResourceValueLocalization.ResourceID+"and Culture : "+ResourceValueLocalization.LanguageCode+"and Application Name: "+ResourceValueLocalization.ApplicationName+"("+ResourceValueLocalization.ApplicationID+") and Page Name : "+ResourceValueLocalization.PageName+"and Page ID:"+ResourceValueLocalization.PageID);
                }else
                {
                    _logger.addMessage.Add("GetExistingResource", "Resource Value:- "+ResourceValueLocalization.ResourceValue+" - Exist Against Resource Key: " + ResourceValueLocalization.ResourceID + "and Culture : " + ResourceValueLocalization.LanguageCode + "and Application Name: " + ResourceValueLocalization.ApplicationName + "(" + ResourceValueLocalization.ApplicationID + ") and Page Name : " + ResourceValueLocalization.PageName + "and Page ID:" + ResourceValueLocalization.PageID);
                }
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetExistingResource", "Error During  GetExistingResource" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, ResourceValueLocalization);
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

        [Tokenizer]
        [Route("UpdateResource")]
        [HttpPost]
        public HttpResponseMessage UpdateResource(LocalizationModel objLocalizationModel)
        {

            bool status = false;
            try
            {
                _logger.addMessage.Add("UpdateResource", "UpdateResource Method is goint to Execute");

                ManageLocalization objManageLocalization = new ManageLocalization();
                status = objManageLocalization.UpdateResourceValue(objLocalizationModel);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("AddNewResource", "Error During  UpdateResource" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, status);
        }


        [Tokenizer]
        [Route("getResources")]
        [HttpPost]
        public HttpResponseMessage getResources(LocalizationModel objLocalizationModel)
        {

            string ResourcesContent = string.Empty;
            try
            {
                _logger.addMessage.Add("getResources", "getResources Method is goint to Execute");

                ManageLocalization objManageLocalization = new ManageLocalization();
                ResourcesContent = objManageLocalization.GetResourceList(objLocalizationModel);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("getResources", "Error During  getResources" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, ResourcesContent);
        }


    }
}
