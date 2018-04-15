using System.Web.Mvc;

namespace PackageModule.Areas.PackageCosting
{
    public class PackageCostingAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PackageCosting";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PackageCosting_default",
                "PackageCosting/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}