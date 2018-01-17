using PackageModule.Utility;
using SoftdebuggerWebsite.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackageModule.Areas.Admin.Controllers
{
    [LocalizationFilter]
    public class PackageController : Controller
    {
        // GET: Admin/Package
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateNewPackage()
        {
            ViewBag.AddLocalizationLangFile = CommonFunction.GetResources("CreateNewPackage");
            return View();
        }

        public ActionResult UpdatePackage()
        {
            ViewBag.AddLocalizationLangFile = CommonFunction.GetResources("UpdatePackage");
            return View();
        }

        [ActionName("ActivePackageProduct")]
        public ActionResult ActivePackageProduct()
        {
            return View();
        }

       
    }
}