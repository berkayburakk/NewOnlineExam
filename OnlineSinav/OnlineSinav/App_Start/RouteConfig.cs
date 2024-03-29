﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OnlineSinav.Controllers;

namespace OnlineSinav
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Home", "", new { controller = "Auth", action = "Login" });
            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" });

        }
    }
}
