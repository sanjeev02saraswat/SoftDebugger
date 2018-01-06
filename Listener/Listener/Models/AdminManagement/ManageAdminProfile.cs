using BusinessModels.AdminManagement;
using ConnectorAPI;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WEBAPI2.Utilities;

namespace Listener.Models.AdminManagement
{
    public class ManageAdminProfile
    {
        private AsyncLogger _logger = null;
        public ManageAdminProfile()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "Listener.Models.AdminManagement.ManageAgentProfile";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();

        }

        public string GetAgentProfile(string CompanyID,String TokenID)
        {
            string GetAgentProfile = string.Empty;
            try
            {

                _logger.addMessage.Add("GetAgentProfile", "GetAgentProfile Method is goint to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);
                _logger.addMessage.Add("TokenID", TokenID);
                objparamlist.Add("TokenID", TokenID);

                IConnector objConnector = new Connector();
                DataTable AdminUserDetail = objConnector.ExecuteDataTable("CompanyAdmin", "FSP_GetAgentProfileDetails", objparamlist);
                _logger.addMessage.Add("GetAgentProfile", "GetAgentProfile Method executed  successfully");
                GetAgentProfile = CommonUtility.GetDataTableToJSONSingleRow(AdminUserDetail);
                _logger.addMessage.Add("GetAgentProfile", " Returned Agent Profile Data: " + GetAgentProfile);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetAgentProfile", "Error during Get Agent Profile Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return GetAgentProfile;
        }




        public bool UpdateAgentProfile(AgentProfile objAdminProfile)
        {
            bool status = false;
            try
            {

                _logger.addMessage.Add("UpdateAgentProfile", "UpdateAgentProfile Method is goint to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", objAdminProfile.CompanyID);
                objparamlist.Add("CompanyID", objAdminProfile.CompanyID);
                _logger.addMessage.Add("TokenID", objAdminProfile.TokenID);
                objparamlist.Add("TokenID", objAdminProfile.TokenID);
                _logger.addMessage.Add("FirstName", objAdminProfile.FirstName);
                objparamlist.Add("FirstName", objAdminProfile.FirstName);
                _logger.addMessage.Add("LastName", objAdminProfile.LastName);
                objparamlist.Add("LastName", objAdminProfile.LastName);
                _logger.addMessage.Add("Language", objAdminProfile.Language);
                objparamlist.Add("Language", objAdminProfile.Language);
                _logger.addMessage.Add("Country", objAdminProfile.Country);
                objparamlist.Add("Country", objAdminProfile.Country);
                _logger.addMessage.Add("Address", objAdminProfile.Address);
                objparamlist.Add("Address", objAdminProfile.Address);
                _logger.addMessage.Add("Phone", objAdminProfile.Phone);
                objparamlist.Add("Phone", objAdminProfile.Phone);
                _logger.addMessage.Add("Email", objAdminProfile.Email);
                objparamlist.Add("Email", objAdminProfile.Email);
                _logger.addMessage.Add("DefaultPage", objAdminProfile.DefaultPage);
                objparamlist.Add("DefaultPage", objAdminProfile.DefaultPage);


                IConnector objConnector = new Connector();
                 status = objConnector.ExecuteNonQuery("CompanyAdmin", "FSP_UpdateAgentProfile", objparamlist);
                _logger.addMessage.Add("UpdateAgentProfile", "UpdateAgentProfile Method executed  successfully");
              
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetAdminProfile", "Error during Get Admin Profile Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return status;
        }

    }
}