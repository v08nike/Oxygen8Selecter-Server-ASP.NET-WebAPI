using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;
using Oxygen8SelectorServer.App_Start;

namespace Oxygen8SelectorServer
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }

        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.Filters.Add(new CustomRequireHttpsAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();
            // Web API enable CORS
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: WebApiConfig.UrlPrefix + "/{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional }
            );
        }
    }
}
