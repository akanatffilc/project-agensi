using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Board
{
    public class AgensiQueryCommands
    {
        private static Lazy<QueryVoteDataLogic> QueryVoteDataLogic = new Lazy<QueryVoteDataLogic>(() => { return new QueryVoteDataLogic(); });
        private static Lazy<QueryVoteDownDataLogic> QueryVoteDownDataLogic = new Lazy<QueryVoteDownDataLogic>(() => { return new QueryVoteDownDataLogic(); });
        private static Lazy<QueryViewDataLogic> QueryViewDataLogic = new Lazy<QueryViewDataLogic>(() => { return new QueryViewDataLogic(); });

        public static Task Vote(long queryId, string voteUid)
        {
            QueryVoteDataLogic.Value.Add(new QueryVote
            {
                QueryId = queryId,
                UserId = voteUid,
                AddTime = DateTime.Now
            });
            //return QueryVoteDataLogic.Value.AddAsync(new QueryVote
            //{
            //    QueryId = queryId,
            //    UserId = voteUid,
            //    AddTime = DateTime.Now
            //});
        }

        public static void VoteCancel(long queryId, string voteUid)
        {
            QueryVoteDataLogic.Value.Delete(new QueryVote
            {
                QueryId = queryId,
                UserId = voteUid,
                AddTime = DateTime.Now
            });
            //return QueryVoteDataLogic.Value.DeleteAsync(new QueryVote
            //{
            //    QueryId = QueryId,
            //    Uid = voteUid,
            //    AddTime = DateTime.Now
            //});
        }

        public static void VoteDown(long queryId, string voteDownUid)
        {
            QueryVoteDownDataLogic.Value.Add(new QueryVoteDown
            {
                QueryId = queryId,
                UserId = voteDownUid,
                AddTime = DateTime.Now
            });
            //return QueryVoteDownDataLogic.Value.AddAsync(new QueryVoteDown
            //{
            //    QueryId = QueryId,
            //    Uid = voteDownUid,
            //    AddTime = DateTime.Now
            //});
        }

        public static void VoteDownCancel(long queryId, string voteDownUid)
        {
            QueryVoteDownDataLogic.Value.Delete(new QueryVoteDown
            {
                QueryId = queryId,
                UserId = voteDownUid,
                AddTime = DateTime.Now
            });
            //return QueryVoteDownDataLogic.Value.DeleteAsync(new QueryVoteDown
            //{
            //    QueryId = QueryId,
            //    Uid = voteDownUid,
            //    AddTime = DateTime.Now
            //});
        }

        public static void ViewCountUp(long queryId,string loginUserId)
        {
            QueryViewDataLogic.Value.Add(new QueryView{
                QueryId = queryId,
                UserId = loginUserId,
                AddTime = DateTime.Now
            }); 
        }
    }

}
