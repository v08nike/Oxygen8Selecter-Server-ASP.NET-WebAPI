<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;
=======
﻿using System.Web.Http;
>>>>>>> 5f20095b1b8a9b24870bc1f1889b9505284351df
using Oxyzen8SelectorServer.App_Start;

namespace Oxyzen8SelectorServer
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }

        public static void Register(HttpConfiguration config)
        {
<<<<<<< HEAD
            // Web API configuration and services
            config.Filters.Add(new CustomRequireHttpsAttribute());
=======
            // Web API configuration and services  
            //config.Filters.Add(new CustomRequireHttpsAttribute());
>>>>>>> 5f20095b1b8a9b24870bc1f1889b9505284351df
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
