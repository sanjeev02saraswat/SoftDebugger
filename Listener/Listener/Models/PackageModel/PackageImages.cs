using ConnectorAPI;
using PackageBusinessModel.Models;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Listener.Models.PackageModel
{
   public class ManagePackageImages
    {
        private AsyncLogger _logger = null;
        public ManagePackageImages()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "Listener.Models.PackageModel.ManagePackageImages";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }


        public void AddPackageImages(PackageImages objPackageImages)
        {
            try
            {
                _logger.addMessage.Add("AddPackageImages", "AddPackageImages Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", objPackageImages.CompanyID);
                objparamlist.Add("CompanyID", objPackageImages.CompanyID);

                _logger.addMessage.Add("PackageCode", objPackageImages.PackageCode);
                objparamlist.Add("PackageCode", objPackageImages.PackageCode);

                _logger.addMessage.Add("PackageImageName", objPackageImages.PackageImageName);
                objparamlist.Add("PackageImageName", objPackageImages.PackageImageName);

                _logger.addMessage.Add("PackageImageTitle", objPackageImages.PackageImageTitle);
                objparamlist.Add("PackageImageTitle", objPackageImages.PackageImageTitle);

                IConnector objConnector = new Connector();
                bool status = objConnector.ExecuteNonQuery("PackageModule", "InsertPackageImages", objparamlist);
                _logger.addMessage.Add("AddPackageImages", "Package Images Saved Successfully");
            }
            catch (Exception ex)
            {

                _logger.addMessage.Add("AddPackageImages", "Error during Add Package Images Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
        }
    }
}