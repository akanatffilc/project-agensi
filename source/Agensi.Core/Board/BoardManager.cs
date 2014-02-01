using Agensi.Core.DataLogic.Core;
using Agensi.Core.User;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Board
{
    public class BoardManager
    {
        private static Lazy<AnswerVoteDataLogic> AnswerVoteDataLogic = new Lazy<AnswerVoteDataLogic>(() => { return new AnswerVoteDataLogic(); });
        private static Lazy<AnswerVoteDownDataLogic> AnswerVoteDownDataLogic = new Lazy<AnswerVoteDownDataLogic>(() => { return new AnswerVoteDownDataLogic(); });
        private static Lazy<QueryVoteDataLogic> QueryVoteDataLogic = new Lazy<QueryVoteDataLogic>(() => { return new QueryVoteDataLogic(); });
        private static Lazy<QueryVoteDownDataLogic> QueryVoteDownDataLogic = new Lazy<QueryVoteDownDataLogic>(() => { return new QueryVoteDownDataLogic(); });
        private static Lazy<QueryViewDataLogic> QueryViewDataLogic = new Lazy<QueryViewDataLogic>(() => { return new QueryViewDataLogic(); });




        internal BoardManager(AgensiUser user)
        {
            user = _user;
        }

        private AgensiUser _user;

        #region Query
        public int QueryVote(long queryId)
        {
            return QueryVoteDataLogic.Value.Add(new QueryVote
            {
                QueryId = queryId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
            //QueryVoteDataLogic.Value.AddAsync(new QueryVote
            //{
            //    QueryId = queryId,
            //    UserId = voteUid,
            //    AddTime = DateTime.Now
            //});
        }

        public int QueryVoteCancel(long queryId)
        {
            return QueryVoteDataLogic.Value.Delete(new QueryVote
            {
                QueryId = queryId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
            //QueryVoteDataLogic.Value.DeleteAsync(new QueryVote
            //{
            //    QueryId = queryId,
            //    UserId = voteUid,
            //    AddTime = DateTime.Now
            //});
        }

        public int QueryVoteDown(long queryId)
        {
            return QueryVoteDownDataLogic.Value.Add(new QueryVoteDown
            {
                QueryId = queryId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
            //QueryVoteDownDataLogic.Value.AddAsync(new QueryVoteDown
            //{
            //    QueryId = queryId,
            //    UserId = voteDownUid,
            //    AddTime = DateTime.Now
            //});
        }

        public int QueryVoteDownCancel(long queryId)
        {
            return QueryVoteDownDataLogic.Value.Delete(new QueryVoteDown
            {
                QueryId = queryId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
            //QueryVoteDownDataLogic.Value.DeleteAsync(new QueryVoteDown
            //{
            //    QueryId = queryId,
            //    UserId = voteDownUid,
            //    AddTime = DateTime.Now
            //});
        }

        public void ViewCountUp(long queryId)
        {
            QueryViewDataLogic.Value.Add(new QueryView
            {
                QueryId = queryId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
        }


        #endregion


        #region Answer

        public int AnswerVote(long answerId)
        {
            return AnswerVoteDataLogic.Value.Add(new AnswerVote
            {
                AnswerId = answerId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
            //AnswerVoteDataLogic.Value.AddAsync(new AnswerVote
            //{
            //    AnswerId = answerId,
            //    UserId = voteUid,
            //    AddTime = DateTime.Now
            //});
        }

        public int AnswerVoteCancel(long answerId)
        {
            return AnswerVoteDataLogic.Value.Delete(new AnswerVote
            {
                AnswerId = answerId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
            //AnswerVoteDataLogic.Value.DeleteAsync(new AnswerVote
            //{
            //    AnswerId = answerId,
            //    UserId = voteUid,
            //    AddTime = DateTime.Now
            //});
        }

        public int AnswerVoteDown(long answerId)
        {
            return AnswerVoteDownDataLogic.Value.Add(new AnswerVoteDown
            {
                AnswerId = answerId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
            //AnswerVoteDownDataLogic.Value.AddAsync(new AnswerVoteDown
            //{
            //    AnswerId = answerId,
            //    UserId = voteDownUid,
            //    AddTime = DateTime.Now
            //});
        }

        public int AnswerVoteDownCancel(long answerId)
        {
            return AnswerVoteDownDataLogic.Value.Delete(new AnswerVoteDown
            {
                AnswerId = answerId,
                UserId = _user.UserId,
                AddTime = DateTime.Now
            });
            //AnswerVoteDownDataLogic.Value.DeleteAsync(new AnswerVoteDown
            //{
            //    AnswerId = answerId,
            //    UserId = voteDownUid,
            //    AddTime = DateTime.Now
            //});
        }


        #endregion
    }
}
