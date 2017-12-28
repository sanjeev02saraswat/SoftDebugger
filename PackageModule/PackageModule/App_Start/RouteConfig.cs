﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PackageModule
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new {area="admin", controller = "Home", action = "SignUp", id = UrlParameter.Optional }
            );
        }
    }
}
