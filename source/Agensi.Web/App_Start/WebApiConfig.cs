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
                defaults: new { controller = "User", action = "Follow"}
            );

            config.Routes.MapHttpRoute(
                name: "QueryVote",
                routeTemplate: "api/board/queryvote/{queryId}",
                defaults: new { controller = "Board", action = "QueryVote" }
            );

            config.Routes.MapHttpRoute(
                name: "QueryVoteDown",
                routeTemplate: "api/board/queryvotedown/{queryId}",
                defaults: new { controller = "Board", action = "QueryVoteDown" }
            );

            config.Routes.MapHttpRoute(
                name: "AnswerVote",
                routeTemplate: "api/board/answervote/{answerId}",
                defaults: new { controller = "Board", action = "AnswerVote" }
            );

            config.Routes.MapHttpRoute(
                name: "AnswerVoteDown",
                routeTemplate: "api/board/answerotedown/{answerId}",
                defaults: new { controller = "Board", action = "AnswerVoteDown" }
            );



            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
