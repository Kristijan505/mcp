using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace paup_mcp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            // pokušaj  kreiranja nove defaultne rute - nepotrebno/zakomentirano

            /*routes.MapRoute(
                name: "ServisAdmin",
                url: "{controller}/{action}",
                defaults: new { controller = "ServisAdmin", action = "IndexServisAdmin" }
                );*/
        }

        // update tablice ruta - nepotrebno/zakomentirano

        /*protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }*/

    }
}
