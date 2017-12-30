using ConnectorAPI;
using PackageBusinessModel.Models;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WEBAPI2.Utilities;

namespace Listener.Models.PackageModel
{
    public class PackageListAutoComplete
    {
        private AsyncLogger _logger = null;

        public PackageListAutoComplete()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "Listener.Models.PackageModel.PackageListAutoComplete";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }


        public string GetPackageList(PackageList objPackageList)
        {

            try
            {
                _logger.addMessage.Add("GetPackageList", "GetPackageList Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();

                _logger.addMessage.Add("CompanyID", objPackageList.CompanyID);
                objparamlist.Add("CompanyID", objPackageList.CompanyID);

                _logger.addMessage.Add("LanguageCode", objPackageList.PackageLanguage);
                objparamlist.Add("LanguageCode", objPackageList.PackageLanguage);

                _logger.addMessage.Add("Query", objPackageList.query);
                objparamlist.Add("Query", objPackageList.query);


                _logger.addMessage.Add("GetPackageList", "FSP_GetAutocompleteList is going to call");

                IConnector objConnector = new Connector();
                DataTable dtPackageList = objConnector.ExecuteDataTable("PackageModule", "FSP_GetAutocompleteList", objparamlist);
                _logger.addMessage.Add("GetPackageList", "Get Package List successfully");

                string JSONResult = CommonUtility.GetDataTableToJSON(dtPackageList);
                _logger.addMessage.Add("GetPackageList", "Converted JSON Result"+ JSONResult);
                return JSONResult;
                
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetPackageList", "Error during GetPackageList Method Execution:" + ex.ToString());

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return null;
        }
    }
}