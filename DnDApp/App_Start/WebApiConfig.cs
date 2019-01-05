using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DnDApp
{
    public static class WebApiConfig
    {
        public static string UrlPrefix => "api";
        public static string UrlRelativePrefix => "~/api";
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
       
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
