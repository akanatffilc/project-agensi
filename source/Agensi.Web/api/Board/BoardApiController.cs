using Agensi.Core.Board;
using Agensi.Core.Core;
using Agensi.Web.api.Board.Models;
using Agensi.Web.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Agensi.Web.api.Board
{
    [Authorize]
    public class BoardApiController : AgensiApiController
    {
        [HttpPost]
        public VoteResult QueryVoteUp(long queryId)
        {
            var query = AgensiQuery.Create(queryId);
            if (!query.IsExists)
                return new VoteResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateQueryCommands(query);
            return new VoteResult
            {
                IsSuccess = true,
                VoteStatus = commands.VoteUp()
            };
        }

        [HttpPost]
        public VoteResult QueryVoteDown(long queryId)
        {
            var query = AgensiQuery.Create(queryId);
            if (!query.IsExists)
                return new VoteResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateQueryCommands(query);
            return new VoteResult
            {
                IsSuccess = true,
                VoteStatus = commands.VoteDown()
            };
        }

        [HttpPost]
        public VoteResult AnswerVoteUp(long answerId)
        {
            var answer = AgensiAnswer.Create(answerId);
            if (!answer.IsExists)
                return new VoteResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateAnswerCommands(answer);

            return new VoteResult
            {
                IsSuccess = true,
                VoteStatus = commands.VoteUp()
            };
        }

        [HttpPost]
        public VoteResult AnswerVoteDown(long answerId)
        {
            var answer = AgensiAnswer.Create(answerId);
            if (!answer.IsExists)
                return new VoteResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateAnswerCommands(answer);

            return new VoteResult
            {
                IsSuccess = true,
                VoteStatus = commands.VoteDown()
            };
        }
    }
}
