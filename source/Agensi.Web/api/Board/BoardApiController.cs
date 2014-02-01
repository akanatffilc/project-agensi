using Agensi.Core.Board;
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
        public VoteResult QueryVote(long queryId)
        {
            var query = AgensiQuery.Create(queryId);
            if (!query.IsExists)
                return new VoteResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateQueryCommands(query);

            if(!query.IsVoted(LoginUser.UserId))
            {
                return new VoteResult
                {
                    IsSuccess = true,
                    VoteStatus = commands.VoteUp()
                };
            }
            else
            {
                return new VoteResult
                {
                    IsSuccess = true,
                    VoteStatus = commands.VoteDown()
                };
            }
        }

        [HttpPost]
        public VoteResult AnswerVote(long answerId)
        {
            var answer = AgensiAnswer.Create(answerId);
            if (!answer.IsExists)
                return new VoteResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();
            var commands = manager.CreateAnswerCommands(answer);

            if (!answer.IsVoted(LoginUser.UserId))
            {
                return new VoteResult
                {
                    IsSuccess = true,
                    VoteStatus = commands.VoteUp()
                };
            }
            else
            {
                return new VoteResult
                {
                    IsSuccess = true,
                    VoteStatus = commands.VoteDown()
                };
            }
        }
    }
}
