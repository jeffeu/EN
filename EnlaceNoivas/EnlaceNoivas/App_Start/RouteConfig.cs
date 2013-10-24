using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EnlaceNoivas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "ProfileProvider",
                url: "Provider/{providerName}",
                defaults: new { controller = "Provider", action = "Profile"}
            );
            routes.MapRoute(
                name: "SearchPage",
                url: "Search/SearchProvider/{searched}/{page}",
                defaults: new { controller = "Search", action = "SearchProvider", page = UrlParameter.Optional, searched = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}