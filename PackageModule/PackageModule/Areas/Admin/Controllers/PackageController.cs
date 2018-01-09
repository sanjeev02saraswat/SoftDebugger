using PackageModule.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PackageModule.Areas.Admin.Controllers
{
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
            return View();
        }

        public ActionResult AddPackageProduct()
        {
            return View();
        }

       
    }
}