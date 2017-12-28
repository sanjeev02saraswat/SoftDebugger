using ConnectorAPI;
using PackageBusinessModel.Models;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.Data;
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


        public List<PackageImages> GetPackageImages(string PackageCode, string CompanyID)
        {
            List <PackageImages> objlstPackageImages= null;
            try
            {
                _logger.addMessage.Add("GetPackageImages", "GetPackageImages Method is going to Execute");
                Dictionary<string, object> objparamlist = new Dictionary<string, object>();
                _logger.addMessage.Add("CompanyID", CompanyID);
                objparamlist.Add("CompanyID", CompanyID);

                _logger.addMessage.Add("PackageCode", PackageCode);
                objparamlist.Add("PackageCode", PackageCode);

               
                IConnector objConnector = new Connector();
              DataTable dtPackageImageList  = objConnector.ExecuteDataTable("PackageModule", "GetPackageImages", objparamlist);
                _logger.addMessage.Add("GetPackageImages", "Package Images find Successfully");
                if (dtPackageImageList.Rows.Count>0)
                {
                    objlstPackageImages = new List<PackageImages>();
                  
                    for (int i = 0; i < dtPackageImageList.Rows.Count; i++)
                    {
                        PackageImages objPackageImages = new PackageImages();
                        objPackageImages.CompanyID = CompanyID;
                        objPackageImages.PackageCode = PackageCode;
                        objPackageImages.PackageImageName = dtPackageImageList.Rows[i]["Name"].ToString();
                        objPackageImages.PackageImageTitle = dtPackageImageList.Rows[i]["Title"].ToString();
                        objlstPackageImages.Add(objPackageImages);
                    }

                }
                else
                {
                    _logger.addMessage.Add("GetPackageImages", "No Package Images find for Package Code="+PackageCode);

                }
            }
            catch (Exception ex)
            {

                _logger.addMessage.Add("GetPackageImages", "Error during Get Package Images Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return objlstPackageImages;
        }
    }
}