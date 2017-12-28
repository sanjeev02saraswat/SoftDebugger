using Listener.Models.PackageModel;
using PackageBusinessModel.Models;
using PackageModule.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WEBAPI2.Filters;
using WEBAPI2.Utilities;



namespace Listener.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Package")]
    public class PackageController : ApiController
    {

        private AsyncLogger _logger = null;
        public PackageController()
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.PackageController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }

        [HttpPost]
        [Tokenizer]
        [Route("CreateNewPackage")]
        public HttpResponseMessage CreatePackage(PackageDetails objPackageDetails)
        {
            try
            {
                _logger.addMessage.Add("CreatePackage", "CreatePackage Method is goint to Execute");
                CreatePackage objCreatePackage = new CreatePackage();

                objCreatePackage.AddPackage(objPackageDetails);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, null);
        }

        [HttpGet]
        [Tokenizer]
        [Route("GetPackageCode")]
        public HttpResponseMessage GetPackageCode()
        {
            string PackageCode = "";


            try
            {
                _logger.addMessage.Add("GetPackageCode", "GetPackageCode Method is goint to Execute");
                PackageInfo objPackageInfo = new PackageInfo();
                PackageCode = objPackageInfo.GetPackageCode();
                _logger.addMessage.Add("PackageCode", PackageCode);

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetPackageCode", "Error During getting Package Code" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, PackageCode);
        }

        [HttpPost]
        [Tokenizer]
        [Route("UploadPackageImage")]
        //before working it properly install further ste
        //Install-Package MultipartDataMediaFormatter.V2 from nuget
        //add multi media type in global.asax https://www.codeproject.com/Tips/652633/ASP-NET-WebApi-MultipartDataMediaFormatter
        public HttpResponseMessage SavePackageImages(PackageImages objPackageImages)
        {

            try
            {
                if (HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedPackageFile = HttpContext.Current.Request.Files["UploadedImage"];

                    if (httpPostedPackageFile != null)
                    {
                        string fname;
                        fname = System.Web.Hosting.HostingEnvironment.MapPath("~/PackageImages/" + objPackageImages.CompanyID + "/" + objPackageImages.PackageCode);
                        if (!Directory.Exists(fname))
                        {
                            Directory.CreateDirectory(fname);

                        }
                        fname = Path.Combine(fname, objPackageImages.PackageImageName + "." + httpPostedPackageFile.FileName.Split('.')[1].ToString());
                        objPackageImages.PackageImageName = objPackageImages.PackageImageName + "." + httpPostedPackageFile.FileName.Split('.')[1].ToString();
                        httpPostedPackageFile.SaveAs(fname);
                    }
                }
                ManagePackageImages objManagePackageImages = new ManagePackageImages();
                objManagePackageImages.AddPackageImages(objPackageImages);
                _logger.addMessage.Add("SavePackageImages", "Package Images Inserted Successfully");
                return CommonUtility.CreateResponse(HttpStatusCode.OK, null);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("SavePackageImages", "Error During SavePackageImages" + ex.ToString());
                return CommonUtility.CreateResponse(HttpStatusCode.BadRequest, null);
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
         
        }

        [HttpGet]
        [Tokenizer]
        [Route("GetPackageImages")]
        public HttpResponseMessage GetPackageImages(string PackageCode,string CompanyID)
        {
            List<PackageImages> objPackageImages = null;
            try
            {
                _logger.addMessage.Add("GetPackageImages", "GetPackageImages Method is goint to Execute");
                _logger.addMessage.Add("PackageCode", PackageCode);
                _logger.addMessage.Add("CompanyID", CompanyID);
                ManagePackageImages objManagePackageImages = new ManagePackageImages();
               objPackageImages = objManagePackageImages.GetPackageImages(PackageCode, CompanyID);
               

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetPackageImages", "Error During getting Package Images" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, objPackageImages);

        }
    }
}
