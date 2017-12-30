using ConnectorAPI;
using PackageBusinessModel.Models;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WEBAPI2.Utilities;

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

        public string GetPackageDetails(PackageList objPackageList)
        {

            try
            {
                _logger.addMessage.Add("GetPackageDetails", "GetPackageDetails Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();

                _logger.addMessage.Add("CompanyID", objPackageList.CompanyID);
                objparamlist.Add("CompanyID", objPackageList.CompanyID);

                _logger.addMessage.Add("PackageLanguage", objPackageList.PackageLanguage);
                objparamlist.Add("PackageLanguage", objPackageList.PackageLanguage);

                _logger.addMessage.Add("PackageCode", objPackageList.PackageCode);
                objparamlist.Add("PackageCode", objPackageList.PackageCode);


                _logger.addMessage.Add("GetPackageDetails", "FSP_GetPackageDetails is going to call");

                IConnector objConnector = new Connector();
                DataSet dtPackageList = objConnector.ExecuteDataSet("PackageModule", "FSP_GetPackageDetails", objparamlist);
                _logger.addMessage.Add("GetPackageDetails", "Get Package Details Get successfully");
                dtPackageList.Tables[0].TableName = "BasicPackageDetails";
                dtPackageList.Tables[1].TableName = "BasicPackageCreteria";
                string JSONResult = CommonUtility.DataSettoJSON(dtPackageList);
                _logger.addMessage.Add("GetPackageDetails", "Converted JSON Result" + JSONResult);
                return JSONResult;

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetPackageDetails", "Error during GetPackageDetails Method Execution:" + ex.ToString());

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return null;
        }


    }
}