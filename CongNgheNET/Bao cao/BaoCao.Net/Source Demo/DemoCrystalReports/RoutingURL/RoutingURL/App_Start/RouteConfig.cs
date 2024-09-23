using RoutingURL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoutingURL
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // Get CustomerID
            northwindEntities db = new northwindEntities();
            foreach (var item in db.Customers.ToList<Customer>())
            {
                // Get Customer For ID
                routes.MapRoute(
                    item.CustomerID,                                                                // Route name
                    item.CustomerID,                                                                // URL with parameters
                    new { controller = "Customers", action = "Details", id = item.CustomerID }      // Parameter defaults
                );
            }
            routes.MapRoute(
               "Customers",                                             // Route name
               "Customers",                                             // URL with parameters
               new { controller = "Customers", action = "Index" }       // Parameter defaults
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }       
    }
}
