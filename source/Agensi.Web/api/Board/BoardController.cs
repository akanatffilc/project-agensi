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
    public class BoardController : AgensiApiController
    {
        [HttpPost]
        public VoteResult QueryVote(long queryId)
        {
            var query = AgensiQuery.Create(queryId);
            if (!query.IsExists)
                return new VoteResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();

            if(!query.IsVoted(LoginUser.UserId))
            {
                var voteNum = manager.QueryVote(queryId);
                return new VoteResult
                {
                    IsSuccess = true,
                    IsVote = voteNum > 0
                };
            }
            else
            {
                var cancelNum = manager.QueryVoteCancel(queryId);
                return new VoteResult
                {
                    IsSuccess = true,
                    IsVote = cancelNum <= 0
                };
            }
        }

        [HttpPost]
        public VoteDownResult QueryVoteDown(long queryId)
        {
            var query = AgensiQuery.Create(queryId);
            if (!query.IsExists)
                return new VoteDownResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();

            if (!query.IsVoted(LoginUser.UserId))
            {
                var voteNum = manager.QueryVoteDown(queryId);
                return new VoteDownResult
                {
                    IsSuccess = true,
                    IsVoteDown = voteNum > 0
                };
            }
            else
            {
                var cancelNum = manager.QueryVoteDownCancel(queryId);
                return new VoteDownResult
                {
                    IsSuccess = true,
                    IsVoteDown = cancelNum <= 0
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

            if (!answer.IsVoted(LoginUser.UserId))
            {
                var voteNum = manager.AnswerVote(answerId);
                return new VoteResult
                {
                    IsSuccess = true,
                    IsVote = voteNum > 0
                };
            }
            else
            {
                var cancelNum = manager.AnswerVoteCancel(answerId);
                return new VoteResult
                {
                    IsSuccess = true,
                    IsVote = cancelNum <= 0
                };
            }
        }

        [HttpPost]
        public VoteDownResult AnswerVoteDown(long answerId)
        {
            var answer = AgensiAnswer.Create(answerId);
            if (!answer.IsExists)
                return new VoteDownResult { IsSuccess = false };
            var manager = LoginUser.CreateBoardManager();

            if (!answer.IsVoted(LoginUser.UserId))
            {
                var voteNum = manager.AnswerVoteDown(answerId);
                return new VoteDownResult
                {
                    IsSuccess = true,
                    IsVoteDown = voteNum > 0
                };
            }
            else
            {
                var cancelNum = manager.AnswerVoteDownCancel(answerId);
                return new VoteDownResult
                {
                    IsSuccess = true,
                    IsVoteDown = cancelNum <= 0
                };
            }
        }
    }
}
