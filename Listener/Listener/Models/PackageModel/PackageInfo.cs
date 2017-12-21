using ConnectorAPI;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Listener.Models.PackageModel
{
    public class PackageInfo
    {
        private AsyncLogger _logger = null;
        public PackageInfo()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "Listener.Models.PackageModel.CreatePackage";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }
        public string GetPackageCode()
        {
            string PackageCode = "";
            try
            {
                _logger.addMessage.Add("AddPackage", "AddPackage Method is going to Execute");
              IConnector objConnector = new Connector();
                 PackageCode = Convert.ToString(objConnector.ExecuteScalar("PackageModule", "GetPackageCode"));
                _logger.addMessage.Add("Registeruser", "Agent User sign up successfully");
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("Registeruser", "Error during Register user Method Execution:" + ex.ToString());

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return PackageCode;    
        }
    }
}