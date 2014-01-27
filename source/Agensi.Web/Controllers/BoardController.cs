using Agensi.Core.Board;
using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using Agensi.Web.Core.Controllers;
using Agensi.Web.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agensi.Web.Controllers
{
    public class BoardController : AgensiController
    {
        //
        // GET: /Query/
        public ActionResult Index()
        {
            var model = new BoardIndexModel(LoginUser);
            return View(model);

            
        }

        public ActionResult Ask()
        {
            var model = new AskModel(LoginUser);
            return View(model);
        }

        /// <summary>
        /// TODO: JavascriptからToLanguageをまとめて送りたい
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AskExecute(Query query)
        {
            query.OwnerUserId = LoginUser.UserId;
            query.QueryDate = DateTime.Now;
            query.UpdateTime = DateTime.Now;

            new QueryDataLogic().Add(query);
            return RedirectToAction("Index");
        }

        public ActionResult Thread(long queryId)
        {
            var model = new ThreadModel(LoginUser, queryId);

            if(User.Identity.IsAuthenticated)
            {
                //TODO: Refactor suru hituyou ari
                AgensiQueryCommands.ViewCountUp(queryId, LoginUser.UserId);

            }
            
            return View(model);
        }

        public ActionResult AnswerExecute(Answer answer)
        {
            answer.AnswerUserId = LoginUser.UserId;
            answer.AnswerDate = DateTime.Now;
            answer.UpdateTime = DateTime.Now;

            new AnswerDataLogic().Add(answer);
            return RedirectToAction("Thread", new { queryId = answer.QueryId });
        }

        [HttpPost]
        public ActionResult AnswerVote(long answerId)
        {
            AgensiAnswerCommands.Vote(answerId, LoginUser.UserId);
            var answer = AgensiAnswer.Create(answerId);
            var model = new ThreadModel(LoginUser,answer.QueryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult AnswerVoteCancel(long answerId)
        {
            AgensiAnswerCommands.VoteCancel(answerId, LoginUser.UserId);
            var answer = AgensiAnswer.Create(answerId);
            var model = new ThreadModel(LoginUser, answer.QueryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult AnswerVoteDown(long answerId)
        {
            AgensiAnswerCommands.VoteDown(answerId, LoginUser.UserId);
            var answer = AgensiAnswer.Create(answerId);
            var model = new ThreadModel(LoginUser, answer.QueryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult AnswerVoteDownCancel(long answerId)
        {
            AgensiAnswerCommands.VoteDownCancel(answerId, LoginUser.UserId);
            var answer = AgensiAnswer.Create(answerId);
            var model = new ThreadModel(LoginUser, answer.QueryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult QueryVote(long queryId)
        {
            AgensiQueryCommands.Vote(queryId, LoginUser.UserId);
            var model = new ThreadModel(LoginUser, queryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult QueryVoteCancel(long queryId)
        {
            AgensiQueryCommands.VoteCancel(queryId, LoginUser.UserId);
            var model = new ThreadModel(LoginUser, queryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult QueryVoteDown(long queryId)
        {
            AgensiQueryCommands.VoteDown(queryId, LoginUser.UserId);
            var model = new ThreadModel(LoginUser, queryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult QueryVoteDownCancel(long queryId)
        {
            AgensiQueryCommands.VoteDownCancel(queryId, LoginUser.UserId);
            var model = new ThreadModel(LoginUser, queryId);
            return View("Thread", model);
        }
	}
}