using Listener.Filters;
using Listener.Models.PackageModel;
using PackageBusinessModel.Models;
using SoftLoggerAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using PackageModule.Utilities;
using PackageModuleLayer.Models.PackageModel;
using Newtonsoft.Json;
using BusinessModels.PackageBusinessModel;

namespace Listener.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Package")]
    public class PackageController : ApiController
    {
        private readonly ManagePackageProducts _objManagePackageProducts;
        private readonly PackageListAutoComplete _objPackageListAutoComplete;
        private AsyncLogger _logger = null;
        public PackageController() : this(new ManagePackageProducts(), new PackageListAutoComplete())
        {
            _logger = new AsyncLogger();
            _logger.FileCollector = "WEBAPI2.Controllers.PackageController";
            _logger.addMessage = new System.Collections.Specialized.NameValueCollection();
        }
        public PackageController(ManagePackageProducts objManagePackageProducts, PackageListAutoComplete objPackageListAutoComplete)
        {
            _objManagePackageProducts = objManagePackageProducts;
            _objPackageListAutoComplete = objPackageListAutoComplete;
        }

        [HttpPost]
        [Tokenizer]
        //[ModelValidator]
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

        [HttpPost]
        [Tokenizer]
        //[ModelValidator]
        [Route("AddHotelCosting")]
        public HttpResponseMessage AddHotelCosting(List<HotelCosting> objHotelCosting)
        {
            try
            {              
                ManagePackageHotelCosting objManagePackageHotelCosting = new ManagePackageHotelCosting();
                bool status = objManagePackageHotelCosting.UpdatePackageHotelCosting(objHotelCosting);
                if (status)
                {
                    return CommonUtility.CreateResponse(HttpStatusCode.OK, null);
                }
                else
                {
                    return CommonUtility.CreateResponse(HttpStatusCode.InternalServerError, null);
                }

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("AddHotelCosting", "Error during add Package hotel costing Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.InternalServerError, null);
        }

        [HttpPost]
        [Tokenizer]
        [Route("GetHotelCosting")]
        public HttpResponseMessage GetHotelCosting(HotelCostingRequest objHotelCostingRequest)
        {
            List<HotelCosting> objHotelCosting = null;
            try
            {
                _logger.addMessage.Add("GetHotelCosting", "GetHotelCosting Method is going to excute");
                ManagePackageHotelCosting objManagePackageHotelCosting = new ManagePackageHotelCosting();
                objHotelCosting = objManagePackageHotelCosting.GetPackageHotelCosting(objHotelCostingRequest);
                _logger.addMessage.Add("GetHotelCosting", "GetHotelCosting Method result" + JsonConvert.SerializeObject(objHotelCosting));

            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetHotelCosting", "Error during add get hotel costing Method Execution:" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, objHotelCosting);
        }



        [HttpPost]
        [Tokenizer]
        [Route("GetPackages")]
        public HttpResponseMessage GetPackages(PackageList objAirportList)
        {
            string JSONResult = "";
            try
            {
                _logger.addMessage.Add("GetPackages", "GetPackages Method is goint to Execute");
                JSONResult = _objPackageListAutoComplete.GetPackageList(objAirportList);



            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetPackages", "Error during GetPackages  Method Execution:" + ex.ToString());
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, JSONResult);
        }

        [HttpGet]        
        [Route("GetPackagesAutocomplete")]
        public HttpResponseMessage GetPackagesAutocomplete(string query,string companyid,string packagelanguage)
        {
            PackageList objPackageList = new PackageList();
            string JSONResult = "";
            List<PackageList> objallPackageList = new List<PackageList>();
            try
            {
                objPackageList.query = query;
                objPackageList.CompanyID = companyid;
                objPackageList.PackageLanguage = packagelanguage;
                _logger.addMessage.Add("GetPackages", "GetPackages Method is goint to Execute");
                JSONResult = _objPackageListAutoComplete.GetPackageList(objPackageList);
                objallPackageList = JsonConvert.DeserializeObject<List<PackageList>>(JSONResult);
            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetPackages", "Error during GetPackages  Method Execution:" + ex.ToString());
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, objallPackageList);
        }

        /// <summary>
        /// for test Purpose
        /// </summary>
        /// <param name="objPackageList"></param>
        /// <returns></returns>
        [HttpGet]
        // [Tokenizer]
        [Route("GetPackages")]
        public HttpResponseMessage GetPackages(string CompanyID)
        {
            string JSONResult = "";
            try
            {
                _logger.addMessage.Add("GetPackages", "GetPackages Method is goint to Execute");
                PackageListAutoComplete objPackageListAutoComplete = new PackageListAutoComplete();

                // JSONResult = objPackageListAutoComplete.GetPackageList(objPackageList);



            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetPackages", "Error during GetPackages  Method Execution:" + ex.ToString());
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, JSONResult);
        }

        [HttpPost]
        [Tokenizer]
        [Route("GetPackageDetail")]
        public HttpResponseMessage GetPackageDetail(PackageList objPackageList)
        {
            string JSONResult = "";
            try
            {
                _logger.addMessage.Add("GetPackageDetail", "GetPackageDetail Method is goint to Execute");
                PackageInfo objPackageInfo = new PackageInfo();

                JSONResult = objPackageInfo.GetPackageDetails(objPackageList);
                //PackageDetails data = JsonConvert.DeserializeObject<PackageDetails>(JSONResult);
                //PackageDetails objPackageDetails = new PackageDetails();
                //objPackageDetails.BasicPackageCreteria = null;

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("GetPackageDetail", "Error during GetPackageDetail  Method Execution:" + ex.ToString());
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, JSONResult);
        }

        [HttpPost]
        [Tokenizer]
        [Route("SetDefaultVirtualImage")]
        public HttpResponseMessage SetDefaultVirtualImage(PackageImages objPackageImages)
        {
            try
            {
                _logger.addMessage.Add("SetDefaultVirtualImage", "SetDefaultVirtualImage Method is goint to Execute");
                ManagePackageImages objManagePackageImages = new ManagePackageImages();

                objManagePackageImages.SetDefaultVirtualImage(objPackageImages);

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("SetDefaultVirtualImage", "Error during SetDefaultVirtualImage  Method Execution:" + ex.ToString());
                _logger.ExceptionError = true;

            }
            finally
            {
                AsyncLogger.LogMessage(_logger);
            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, null);
        }

        [HttpPost]
        [Tokenizer]
        [Route("DeletePackageImage")]
        public HttpResponseMessage DeletePackageImage(PackageImages objPackageImages)
        {
            try
            {
                _logger.addMessage.Add("DeletePackageImage", "DeletePackageImage Method is goint to Execute");
                ManagePackageImages objManagePackageImages = new ManagePackageImages();

                objManagePackageImages.DeletePackageImage(objPackageImages);

            }
            catch (Exception ex)
            {
                _logger.addMessage.Add("DeletePackageImage", "Error during DeletePackageImage  Method Execution:" + ex.ToString());
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
                    string autoid = Guid.NewGuid().ToString();
                    objPackageImages.PackageImageName = objPackageImages.PackageImageName + "_" + autoid;
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
        public HttpResponseMessage GetPackageImages(string PackageCode, string CompanyID, string PackageLanguage)
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


        [HttpPost]
        [Tokenizer]
        [Route("InsertPackageCancellationPolicy")]
        public HttpResponseMessage InsertPackageCancellationPolicy(PackageDetails objPackageCancellationPolicy)
        {
            try
            {
                _logger.addMessage.Add("InsertPackageCancellationPolicy", "InsertPackageCancellationPolicy Method is goint to Execute");

                ManagePackageCancellationPolicy objManagePackageCancellationPolicy = new ManagePackageCancellationPolicy();
                objManagePackageCancellationPolicy.InsertPackageCancellationPolicy(objPackageCancellationPolicy);


            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("InsertPackageCancellationPolicy", "Error During inserting Package Cancellation Policy :" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, null);

        }


        //FSP_GetAvailableProductForPackage

        [HttpGet]
        [Tokenizer]
        [Route("GetPackageProducts")]
        public HttpResponseMessage GetPackageProducts(string CompanyID, string LanguageCode)
        {
            string AvailableProducts = string.Empty;
            try
            {
                _logger.addMessage.Add("GetPackageProducts", "GetPackageProducts Method is goint to Execute");
                _logger.addMessage.Add("LanguageCode", LanguageCode);
                _logger.addMessage.Add("CompanyID", CompanyID);
                AvailableProducts = _objManagePackageProducts.GetAvailableProducts(CompanyID, LanguageCode);
                List<PackageProduct> objPackageProductlst = JsonConvert.DeserializeObject<List<PackageProduct>>(AvailableProducts);
                return CommonUtility.CreateResponse(HttpStatusCode.OK, objPackageProductlst);
            }
            catch (Exception ex)
            {
                _logger.ExceptionError = true;
                _logger.addMessage.Add("GetPackageProducts", "Error During getting Package Products" + ex.ToString());
            }
            finally
            {
                AsyncLogger.LogMessage(_logger);

            }
            return CommonUtility.CreateResponse(HttpStatusCode.OK, null);

        }
    }
}
