using BusinessModels.AdminManagement;
using ConnectorAPI;
using PackageModule.Utilities;
using SoftLoggerAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Listener.Models.AdminManagement
{
    public class ManageCompanyProfile
    {
        private AsyncLogger _logger = null;
        public ManageCompanyProfile()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "Listener.Models.AdminManagement.ManageCompanyProfile";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();

        }

        public string GetCompanyDetails(string CompanyID,string TokenID)
        {
            string CompanyDetailsData = string.Empty;
            try
            {
                _logger.addMessage.Add("GetCompanyDetails", "GetCompanyDetails Method is goint to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);
                _logger.addMessage.Add("TokenID", TokenID);
                objparamlist.Add("TokenID", TokenID);
                IConnector objConnector = new Connector();
                DataTable CompanyDetails = objConnector.ExecuteDataTable("CompanyAdmin", "FSP_GetCompanyDetails", objparamlist);
                _logger.addMessage.Add("GetCompanyDetails", "GetCompanyDetails Method executed  successfully");
                CompanyDetailsData = CommonUtility.GetDataTableToJSONSingleRow(CompanyDetails);
                _logger.addMessage.Add("GetCompanyDetails", " Returned Company Profile Data: " + CompanyDetailsData);


            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetCompanyDetails", "Error during GET company details Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CompanyDetailsData;

        }

        public bool UpdateCompanyDetails(CompanyDetails objCompanyDetails)
        {
            bool status = true;
            try
            {
                _logger.addMessage.Add("GetAgentProfile", "GetAgentProfile Method is goint to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", objCompanyDetails.CompanyID);
                objparamlist.Add("CompanyID", objCompanyDetails.CompanyID);

               

                _logger.addMessage.Add("CompanyAddress", objCompanyDetails.CompanyAddress);
                objparamlist.Add("CompanyAddress", objCompanyDetails.CompanyAddress);

                _logger.addMessage.Add("CompanyEmail", objCompanyDetails.CompanyEmail);
                objparamlist.Add("CompanyEmail", objCompanyDetails.CompanyEmail);

                _logger.addMessage.Add("CompanyName", objCompanyDetails.CompanyName);
                objparamlist.Add("CompanyName", objCompanyDetails.CompanyName);

                _logger.addMessage.Add("CompanyPANNumber", objCompanyDetails.CompanyPANNumber);
                objparamlist.Add("CompanyPANNumber", objCompanyDetails.CompanyPANNumber);

                _logger.addMessage.Add("CompanyPostalCode", objCompanyDetails.CompanyPostalCode);
                objparamlist.Add("CompanyPostalCode", objCompanyDetails.CompanyPostalCode);

                _logger.addMessage.Add("CompanyTANNumber", objCompanyDetails.CompanyTANNumber);
                objparamlist.Add("CompanyTANNumber", objCompanyDetails.CompanyTANNumber);

                _logger.addMessage.Add("CompanyWebsite", objCompanyDetails.CompanyWebsite);
                objparamlist.Add("CompanyWebsite", objCompanyDetails.CompanyWebsite);

                _logger.addMessage.Add("Country", objCompanyDetails.Country);
                objparamlist.Add("Country", objCompanyDetails.Country);

                _logger.addMessage.Add("CurrencyCode", objCompanyDetails.CurrencyCode);
                objparamlist.Add("CurrencyCode", objCompanyDetails.CurrencyCode);

                _logger.addMessage.Add("DefaultLanguage", objCompanyDetails.DefaultLanguage);
                objparamlist.Add("DefaultLanguage", objCompanyDetails.DefaultLanguage);

                _logger.addMessage.Add("FAX", objCompanyDetails.FAX);
                objparamlist.Add("FAX", objCompanyDetails.FAX);


                _logger.addMessage.Add("Phone", objCompanyDetails.Phone);
                objparamlist.Add("Phone", objCompanyDetails.Phone);

                _logger.addMessage.Add("CompanyLogoURL", objCompanyDetails.CompanyLogoURL);
                objparamlist.Add("CompanyLogoURL", objCompanyDetails.CompanyLogoURL);

                IConnector objConnector = new Connector();
               status=  objConnector.ExecuteNonQuery("CompanyAdmin", "FSP_UpdateCompanyDetails", objparamlist);
                _logger.addMessage.Add("UpdateCompanyDetails", "UpdateCompanyDetails Method executed  successfully");
                
                
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("UpdateCompanyDetails", "Error during update company details Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return status;
        }

    }
}