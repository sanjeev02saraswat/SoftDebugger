using BusinessModels.PackageBusinessModel;
using Newtonsoft.Json;
using PackageBusinessModel.Models;
using PackageModule.Utility;
using SoftdebuggerWebsite.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackageModule.Areas.PackageCosting.Controllers
{
    [LocalizationFilter]

    public class PackageCostingController : Controller
    {
        
      
        // GET: PackageCosting/PackageCosting
        [HttpPost]
        public ActionResult Index(PackageCostingRequestBridgeModel objModel)
        {
            if (Session["listenertoken"] != null)
            {
                Session["BridgeModel"] = objModel;
            }
            return null;
        }

        public ActionResult ManagePackageCosing()
        {
            if (Session["listenertoken"] != null && Session["BridgeModel"] != null)
            {

                return RedirectToAction("Checkingyourauthentication");

            }
            else
            {
                return RedirectToAction("Signup", "Home", new { area = "Admin" });

            }
        }
        public ActionResult Checkingyourauthentication()
        {
            PackageCostingRequestBridgeModel objModel = (PackageCostingRequestBridgeModel)Session["BridgeModel"];
            if (CommonFunction.ValidateToken(objModel.TokenID, objModel.CompanyID))
            {
                string ActionName = objModel.RequestTo.ToString();
                return RedirectToAction("" + ActionName + "");
            }
            return RedirectToAction("Signup", "Home", new { area = "Admin" });
        }

        public ActionResult AddCosing()
        {
            if (Session["BridgeModel"]!=null)
            {
                PackageCostingRequestBridgeModel objModel = (PackageCostingRequestBridgeModel)Session["BridgeModel"];
                string CultureCode = CommonFunction.GetFileCulture();
                string ValidationTokenURL = System.Configuration.ConfigurationManager.AppSettings["ListnerUrl"].ToString() + "Package/GetPackageProducts?LanguageCode=" + CultureCode + "&CompanyID=" + objModel.CompanyID;
                Dictionary<string, string> objparamlist = new Dictionary<string, string>();
                
                objparamlist.Add("CompanyID", objModel.CompanyID);
                objparamlist.Add("tokenid", objModel.TokenID);
                string Response = CommonFunction.HITAPI("", ValidationTokenURL, "GET", objparamlist);
                if (!string.IsNullOrEmpty(Response))
                {
                    List<PackageProduct> objPackageProductlst = JsonConvert.DeserializeObject<List<PackageProduct>>(Response);
                    ViewBag.objPackageProductlst = objPackageProductlst;
                }
                ViewBag.BridgeModel = objModel;
                return View();
            }
            return RedirectToAction("Signup", "Home", new { area = "Admin" });
        }


        public ActionResult UpdateCosting()
        {
            if (Session["BridgeModel"] != null)
            {
                PackageCostingRequestBridgeModel objModel = (PackageCostingRequestBridgeModel)Session["BridgeModel"];
                string CultureCode = CommonFunction.GetFileCulture();
                string ValidationTokenURL = System.Configuration.ConfigurationManager.AppSettings["ListnerUrl"].ToString() + "Package/GetPackageProducts?LanguageCode=" + CultureCode + "&CompanyID=" + objModel.CompanyID;
                Dictionary<string, string> objparamlist = new Dictionary<string, string>();

                objparamlist.Add("CompanyID", objModel.CompanyID);
                objparamlist.Add("tokenid", objModel.TokenID);
                string Response = CommonFunction.HITAPI("", ValidationTokenURL, "GET", objparamlist);
                if (!string.IsNullOrEmpty(Response))
                {
                    List<PackageProduct> objPackageProductlst = JsonConvert.DeserializeObject<List<PackageProduct>>(Response);
                    ViewBag.objPackageProductlst = objPackageProductlst;
                }
                ViewBag.BridgeModel = objModel;
                return View();
            }
            return RedirectToAction("Signup", "Home", new { area = "Admin" });
        }
    }
}