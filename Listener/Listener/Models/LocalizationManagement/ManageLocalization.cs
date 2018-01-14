using BusinessModels.LocalizationModel;
using ConnectorAPI;
using SoftLoggerAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using PackageModule.Utilities;

namespace Listener.Models.LocalizationManagement
{
    public class ManageLocalization
    {
        private AsyncLogger _logger = null;
        public ManageLocalization()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "Listener.Models.LocalizationManagement.ManageLocalization";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }


        public string GetApplications(string CompanyID)
        {
            string AppList = string.Empty;
            try
            {
                _logger.addMessage.Add("GetApplications", "GetApplications Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();

                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);

                IConnector objConnector = new Connector();
                DataTable dtAppList = objConnector.ExecuteDataTable("CompanyAdmin", "FSP_GetApplications",objparamlist);
                _logger.addMessage.Add("GetApplications", "GetApplications Method executed  successfully");
                 AppList = CommonUtility.GetDataTableToJSON(dtAppList);
                _logger.addMessage.Add("GetApplications", "Application List: "+ AppList);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetApplications", "Error during Get Applications Method Execution:" + ex.ToString());

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return AppList;
        }


        public string GetPageList(string CompanyID,string ApplicationID)
        {
            string PageList = string.Empty;
            try
            {
                _logger.addMessage.Add("GetPageList", "GetPageList Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();

                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);
                _logger.addMessage.Add("ApplicationID", ApplicationID);
                objparamlist.Add("ApplicationID", ApplicationID);

                IConnector objConnector = new Connector();
                DataTable dtPageList = objConnector.ExecuteDataTable("CompanyAdmin", "FSP_GetPageList", objparamlist);
                _logger.addMessage.Add("GetPageList", "GetPageList Method executed  successfully");
               PageList = CommonUtility.GetDataTableToJSON(dtPageList);
                _logger.addMessage.Add("GetPageList", "Page List: " + PageList);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetPageList", "Error during Get Page List Method Execution:" + ex.ToString());

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return PageList;
        }

        public string GetResourcesContent(string CompanyID, string ApplicationName, string PageName, string Culture="en-US")
        {
            string ResourceContent = string.Empty;
            try
            {
                _logger.addMessage.Add("GetResourcesContent", "GetResourcesContent Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();

                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);
                _logger.addMessage.Add("ApplicationName", ApplicationName);
                objparamlist.Add("ApplicationName", ApplicationName);
                _logger.addMessage.Add("PageName", PageName);
                objparamlist.Add("PageName", PageName);
                _logger.addMessage.Add("Culture", Culture);
                objparamlist.Add("Culture", Culture);

                IConnector objConnector = new Connector();
                DataTable dtPageList = objConnector.ExecuteDataTable("Localization", "FSP_GetPageResources", objparamlist);
                _logger.addMessage.Add("GetResourcesContent", "GetResourcesContent Method executed  successfully");
                ResourceContent = CommonUtility.GetDataTableResourceToJSON(dtPageList);
                _logger.addMessage.Add("GetResourcesContent", "GetResourcesContent: " + ResourceContent);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetResourcesContent", "Error during Get Resources Method Execution:" + ex.ToString());

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return ResourceContent;
        }


        public bool AddNewResourceKey(LocalizationModel objLocalizationModel)
        {
            bool InsertedResource = false;


            try
            {
                _logger.addMessage.Add("GetResourcesContent", "GetResourcesContent Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();

                _logger.addMessage.Add("CompanyID", objLocalizationModel.CompanyID);
                objparamlist.Add("CompanyID", objLocalizationModel.CompanyID);
                _logger.addMessage.Add("ApplicationID", objLocalizationModel.ApplicationID);
                objparamlist.Add("ApplicationID", objLocalizationModel.ApplicationID);
                _logger.addMessage.Add("PageID", objLocalizationModel.PageID);
                objparamlist.Add("PageID", objLocalizationModel.PageID);
                _logger.addMessage.Add("Culture", objLocalizationModel.LanguageCode);
                objparamlist.Add("Culture", objLocalizationModel.LanguageCode);

                _logger.addMessage.Add("ResourceID", objLocalizationModel.ResourceID);
                objparamlist.Add("ResourceID", objLocalizationModel.ResourceID);

                _logger.addMessage.Add("ResourceValue", objLocalizationModel.ResourceValue);
                objparamlist.Add("ResourceValue", objLocalizationModel.ResourceValue);

                IConnector objConnector = new Connector();
                 InsertedResource = Convert.ToBoolean(objConnector.ExecuteScalar("Localization", "FSP_InsertResources", objparamlist));
                _logger.addMessage.Add("GetResourcesContent", "GetResourcesContent Method executed  successfully");
              
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetResourcesContent", "Error during Get Resources Method Execution:" + ex.ToString());

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return InsertedResource;
        }


    }
}