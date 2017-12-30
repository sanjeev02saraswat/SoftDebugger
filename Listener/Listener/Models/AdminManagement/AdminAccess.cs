using ConnectorAPI;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Listener.Models.AdminManagement
{
    public class AdminAccess
    {
        private AsyncLogger _logger = null;
        public AdminAccess()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "Listener.Models.AdminManagement.AdminAccess";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();

        }


        public void GetAdminAccess(string CompanyID,String TokenID)
        {
            try
            {

                _logger.addMessage.Add("GetAdminAccess", "GetAdminAccess Method is goint to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);
                _logger.addMessage.Add("TokenID", TokenID);
                objparamlist.Add("TokenID", TokenID);               

                IConnector objConnector = new Connector();
                DataTable AdminUserDetail = objConnector.ExecuteDataTable("CompanyAdmin", "ValidateToken", objparamlist);
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetAdminAccess", "Error during GetAdminAccess Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
        }
    }
}