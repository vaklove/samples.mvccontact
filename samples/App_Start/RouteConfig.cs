using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcCodeRouting;
using maxtoroq.apps.web.contact;

namespace Samples {
   
   public class RouteConfig {
      
      public static void RegisterRoutes(RouteCollection routes) {
         
         routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         //routes.MapRoute(
         //    name: "Default",
         //    url: "{controller}/{action}/{id}",
         //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
         //);

         routes.MapCodeRoutes(typeof(Controllers.HomeController));

         ContactConfiguration.Defaults.From = "noreply@example.com";

         routes.MapCodeRoutes(
            baseRoute: "Contact",
            rootController: typeof(ContactController),
            settings: new CodeRoutingSettings {
               EnableEmbeddedViews = true,
               Configuration = new ContactConfiguration {
                  To = "contact@example.com"
               }
            }
         );

         routes.MapCodeRoutes(
            baseRoute: "CustomContact",
            rootController: typeof(ContactController),
            settings: new CodeRoutingSettings {
               EnableEmbeddedViews = true,
               Configuration = new ContactConfiguration {
                  To = "info@example.com",
                  ContactSenderResolver = () => new Models.CustomContactSender()
               }
            }
         );
      }
   }
}