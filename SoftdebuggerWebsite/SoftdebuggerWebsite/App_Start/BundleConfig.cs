using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SoftdebuggerWebsite.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //turn this on if you want to test bundling
            //other wise it will automatically turn on if debug build is off in web.config
            //BundleTable.EnableOptimizations = true;

            //Required for IE7 to be able to handle JSON
            //var ie7Bundle = new ScriptBundle("~/Areas/FlightSearch/Scripts/ie7Js");
            //ie7Bundle.Include("~/Areas/FlightSearch/Content/scripts/libs/json2.js");
            // BundleTable.Bundles.Add(ie7Bundle);

        }
    }
}