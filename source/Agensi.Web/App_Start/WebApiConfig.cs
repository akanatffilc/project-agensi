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

            #region /api/user
            config.Routes.MapHttpRoute(
                name: "UserFollow",
                routeTemplate: "api/user/follow/{toUserId}",
                defaults: new { controller = "UserApi", action = "Follow"}
            );
            #endregion

            #region /api/board
            config.Routes.MapHttpRoute(
                name: "QueryVote",
                routeTemplate: "api/board/queryvoteup/{queryId}",
                defaults: new { controller = "BoardApi", action = "QueryVoteUp" }
            );

            config.Routes.MapHttpRoute(
                name: "QueryVoteDown",
                routeTemplate: "api/board/queryvotedown/{queryId}",
                defaults: new { controller = "BoardApi", action = "QueryVoteDown" }
            );

            config.Routes.MapHttpRoute(
                name: "AnswerVote",
                routeTemplate: "api/board/answervoteup/{answerId}",
                defaults: new { controller = "BoardApi", action = "AnswerVoteUp" }
            );

            config.Routes.MapHttpRoute(
                name: "AnswerVoteDown",
                routeTemplate: "api/board/answerotedown/{answerId}",
                defaults: new { controller = "BoardApi", action = "AnswerVoteDown" }
            );
            #endregion

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
