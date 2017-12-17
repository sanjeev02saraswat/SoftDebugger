using ConnectorAPI;
using PackageBusinessModel.Models;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Listener.Models.PackageModel
{
    public class CreatePackage
    {
        private AsyncLogger _logger = null;
        public CreatePackage()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "Listener.Models.PackageModel.CreatePackage";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }


        public void AddPackage(PackageDetails objPackageDetails)
        {
           
            try
            {
                _logger.addMessage.Add("AddPackage", "AddPackage Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("PackageCode", objPackageDetails.BasicPackageDetails.PackageCode.ToString());
                objparamlist.Add("PackageCode", objPackageDetails.BasicPackageDetails.PackageCode);
                _logger.addMessage.Add("PackageName", objPackageDetails.BasicPackageDetails.PackageName.ToString());
                objparamlist.Add("PackageName", objPackageDetails.BasicPackageDetails.PackageName);
                _logger.addMessage.Add("PackageLanguage", objPackageDetails.BasicPackageDetails.PackageLanguage.ToString());
                objparamlist.Add("PackageLanguage", objPackageDetails.BasicPackageDetails.PackageLanguage);
                _logger.addMessage.Add("PackageTitle", objPackageDetails.BasicPackageDetails.PackageTitle.ToString());
                objparamlist.Add("PackageTitle", objPackageDetails.BasicPackageDetails.PackageTitle);
                _logger.addMessage.Add("PackageMarket", objPackageDetails.BasicPackageCreteria.PackageMarket.ToString());
                objparamlist.Add("PackageMarket", objPackageDetails.BasicPackageCreteria.PackageMarket);

                _logger.addMessage.Add("PackageSaleMarket", objPackageDetails.BasicPackageCreteria.PackageSaleMarket.ToString());
                objparamlist.Add("PackageSaleMarket", objPackageDetails.BasicPackageCreteria.PackageSaleMarket);
                _logger.addMessage.Add("PackageValidityStartDate", objPackageDetails.BasicPackageCreteria.PackageValidityStartDate.ToString());
                objparamlist.Add("PackageValidityStartDate", objPackageDetails.BasicPackageCreteria.PackageValidityStartDate);

                _logger.addMessage.Add("PackageValidityEndDate", objPackageDetails.BasicPackageCreteria.PackageValidityEndDate.ToString());
                objparamlist.Add("PackageValidityEndDate", objPackageDetails.BasicPackageCreteria.PackageValidityEndDate);


                _logger.addMessage.Add("PackageBookingStartDate", objPackageDetails.BasicPackageCreteria.PackageBookingStartDate.ToString());
                objparamlist.Add("PackageBookingStartDate", objPackageDetails.BasicPackageCreteria.PackageBookingStartDate);

                _logger.addMessage.Add("PackageBookingEndDate", objPackageDetails.BasicPackageCreteria.PackageBookingEndDate.ToString());
                objparamlist.Add("PackageBookingEndDate", objPackageDetails.BasicPackageCreteria.PackageBookingEndDate);

                _logger.addMessage.Add("PackageDuration", objPackageDetails.BasicPackageCreteria.PackageDuration.ToString());
                objparamlist.Add("PackageDuration", objPackageDetails.BasicPackageCreteria.PackageDuration);


                _logger.addMessage.Add("ChildMinAge", objPackageDetails.BasicPackageCreteria.ChildMinAge.ToString());
                objparamlist.Add("ChildMinAge", objPackageDetails.BasicPackageCreteria.ChildMinAge);
                _logger.addMessage.Add("ChildMaxAge", objPackageDetails.BasicPackageCreteria.ChildMaxAge.ToString());
                objparamlist.Add("ChildMaxAge", objPackageDetails.BasicPackageCreteria.ChildMaxAge);

                _logger.addMessage.Add("PackageLastPaymentDue", objPackageDetails.BasicPackageCreteria.PackageLastPaymentDue.ToString());
                objparamlist.Add("PackageLastPaymentDue", objPackageDetails.BasicPackageCreteria.PackageLastPaymentDue);

                _logger.addMessage.Add("PackagePaymentCutOffDay", objPackageDetails.BasicPackageCreteria.PackagePaymentCutOffDay.ToString());
                objparamlist.Add("PackagePaymentCutOffDay", objPackageDetails.BasicPackageCreteria.PackagePaymentCutOffDay);


                _logger.addMessage.Add("DiscountonFullPayment", objPackageDetails.BasicPackageCreteria.DiscountonFullPayment.ToString());
                objparamlist.Add("DiscountonFullPayment", objPackageDetails.BasicPackageCreteria.DiscountonFullPayment);




                IConnector objConnector = new Connector();
                bool status = objConnector.ExecuteNonQuery("PackageModule", "FSP_InsertPackageDetails", objparamlist);
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
           
        }
    }
}