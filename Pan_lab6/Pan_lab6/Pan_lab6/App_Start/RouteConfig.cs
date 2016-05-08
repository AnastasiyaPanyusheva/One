using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Pan_lab6
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CreatePage",
                url: "Create",
                defaults: new { controller = "Notebook", action = "CreatePage" }
            );

            routes.MapRoute(
               name: "Default",
               url: "",
               defaults: new { controller = "Notebook", action = "Index" }
           );

            routes.MapRoute(
                name: "Save",
                url: "Save",
                defaults: new { controller = "Notebook", action = "Save", id = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "Image",
                url: "Image",
                defaults: new { controller = "Notebook", action = "Image" }
            );

            routes.MapRoute(
                name: "Load",
                url: "Load",
                defaults: new { controller = "Notebook", action = "Load" }
            );

            routes.MapRoute(
                name: "Select",
                url: "{name}",
                defaults: new { controller = "Notebook", action = "Select", name = "{name}" }
            );
        }
    }
}
