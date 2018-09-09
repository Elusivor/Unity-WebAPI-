using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity_WebAPI_.Handlers;

namespace Unity_WebAPI_
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.MessageHandlers.Add(new FullPipelineTimerHandler());
            //config.MessageHandlers.Add(new APIKeyHandle());
            config.MessageHandlers.Add(new LabAPI04Handler());

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
