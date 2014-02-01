using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Agensi.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "follow",
                routeTemplate: "api/user/follow/{toUserId}",
                defaults: new { controller = "User", action = "Follow"}
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
