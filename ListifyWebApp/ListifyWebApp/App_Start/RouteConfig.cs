using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ListifyWebApp
{
    /// <summary>
    /// RouteConfig describe how url paths should be matched with actions. They also used to generate URL's 
    /// (for links) sent out in responses
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// This is used to create an instance of Route collection class to make the configuration of Routing
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
