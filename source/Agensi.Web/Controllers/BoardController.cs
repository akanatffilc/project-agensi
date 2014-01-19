using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using Agensi.Web.Models.Board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agensi.Web.Controllers
{
    public class BoardController : Controller
    {
        //
        // GET: /Query/
        public ActionResult Index()
        {
            var model = new BoardIndexModel();
            return View(model);
        }


        public ActionResult Ask()
        {
            var model = new AskModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AskExecute(Query query)
        {
            query.OwnerUid = "1";
            query.QueryDate = DateTime.Now;
            query.UpdateTime = DateTime.Now;

            new QueryDataLogic().Add(query);
            return RedirectToAction("Index");
        }

        public ActionResult Thread(long queryId)
        {
            var model = new ThreadModel(queryId);
            return View(model);
        }

        [HttpPost]
        public ActionResult AnswerExecute(Answer answer)
        {
            answer.AnswerUid = "1";
            answer.AnswerDate = DateTime.Now;
            answer.UpdateTime = DateTime.Now;

            new AnswerDataLogic().Add(answer);
            return RedirectToAction("Thread", new { queryId = answer.QueryId });
        }
	}
}