using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Unity_WebAPI_
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //    );

            config.Routes.MapHttpRoute(
                name: "Movie",
                routeTemplate: "api/mov/{id}",
                defaults: new { controller = "movie", id = RouteParameter.Optional }
             );
        }
    }
}
