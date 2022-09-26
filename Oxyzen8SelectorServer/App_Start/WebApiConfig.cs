using System.Web.Http;
using Oxyzen8SelectorServer.App_Start;

namespace Oxyzen8SelectorServer
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
