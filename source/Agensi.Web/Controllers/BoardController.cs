using Agensi.Core.Board;
using Agensi.Core.Board.AgensiQueryTag;
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
        public ActionResult AskExecute(Query query,string Tag = "")
        {
            query.OwnerUserId = LoginUser.UserId;
            query.QueryDate = DateTime.Now;
            query.UpdateTime = DateTime.Now;

            var manager = LoginUser.CreateBoardManager();
            manager.AddQuery(query);

            if (Tag != string.Empty)
                AgensiQueryTagManager.AddQueryTag(query.QueryId, Tag);

            return RedirectToAction("Index");
        }

        public ActionResult Thread(long queryId)
        {
            var model = new ThreadModel(LoginUser, queryId);
            if (!model.AgensiQuery.IsExists)
                return RedirectToAction("Index");

            if(User.Identity.IsAuthenticated)
            {
                var manager = LoginUser.CreateBoardManager();
                var commands = manager.CreateQueryCommands(model.AgensiQuery);
                commands.ViewCountUp();
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult AnswerExecute(Answer answer)
        {
            answer.AnswerUserId = LoginUser.UserId;
            answer.AnswerDate = DateTime.Now;
            answer.UpdateTime = DateTime.Now;

            var manager = LoginUser.CreateBoardManager();
            manager.AddAnswer(answer);

            return RedirectToAction("Thread", new { queryId = answer.QueryId });
        }

        public ActionResult AnswerModify(long answerId,string text)
        {
            var answer = AgensiAnswer.Create(answerId);
            if (!answer.IsExists)
                return RedirectToAction("Index");

            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateAnswerCommands(answer);

            commands.AddChildAnswer(text);

            return RedirectToAction("Thread", new { queryId = answer.QueryId });
        }

        [HttpPost]
        public ActionResult AnswerVote(long answerId)
        {
            var answer = AgensiAnswer.Create(answerId);
            var model = new ThreadModel(LoginUser,answer.QueryId);

            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateAnswerCommands(answer);
            commands.VoteUp();

            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult AnswerVoteCancel(long answerId)
        {
            var answer = AgensiAnswer.Create(answerId);
            var model = new ThreadModel(LoginUser, answer.QueryId);

            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateAnswerCommands(answer);
            commands.VoteDown();


            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult AnswerVoteDown(long answerId)
        {
            var answer = AgensiAnswer.Create(answerId);
            var model = new ThreadModel(LoginUser, answer.QueryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult AnswerVoteDownCancel(long answerId)
        {
            var answer = AgensiAnswer.Create(answerId);
            var model = new ThreadModel(LoginUser, answer.QueryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult QueryVote(long queryId)
        {
            var model = new ThreadModel(LoginUser, queryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult QueryVoteCancel(long queryId)
        {
            var model = new ThreadModel(LoginUser, queryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult QueryVoteDown(long queryId)
        {
            var model = new ThreadModel(LoginUser, queryId);
            return View("Thread", model);
        }

        [HttpPost]
        public ActionResult QueryVoteDownCancel(long queryId)
        {
            var model = new ThreadModel(LoginUser, queryId);
            return View("Thread", model);
        }
	}
}