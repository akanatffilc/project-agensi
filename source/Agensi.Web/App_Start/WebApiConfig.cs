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
                name: "UserFollow",
                routeTemplate: "api/user/follow/{toUserId}",
                defaults: new { controller = "UserApi", action = "Follow"}
            );

            config.Routes.MapHttpRoute(
                name: "QueryVote",
                routeTemplate: "api/board/queryvote/{queryId}",
                defaults: new { controller = "BoardApi", action = "QueryVote" }
            );

            config.Routes.MapHttpRoute(
                name: "QueryVoteDown",
                routeTemplate: "api/board/queryvotedown/{queryId}",
                defaults: new { controller = "BoardApi", action = "QueryVoteDown" }
            );

            config.Routes.MapHttpRoute(
                name: "AnswerVote",
                routeTemplate: "api/board/answervote/{answerId}",
                defaults: new { controller = "BoardApi", action = "AnswerVote" }
            );

            config.Routes.MapHttpRoute(
                name: "AnswerVoteDown",
                routeTemplate: "api/board/answerotedown/{answerId}",
                defaults: new { controller = "BoardApi", action = "AnswerVoteDown" }
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
