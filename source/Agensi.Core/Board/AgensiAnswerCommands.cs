using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Board
{
    public class AgensiAnswerCommands
    {
        private static Lazy<AnswerVoteDataLogic> AnswerVoteDataLogic = new Lazy<AnswerVoteDataLogic>(() => { return new AnswerVoteDataLogic(); });
        private static Lazy<AnswerVoteDownDataLogic> AnswerVoteDownDataLogic = new Lazy<AnswerVoteDownDataLogic>(() => { return new AnswerVoteDownDataLogic(); });

        public static void Vote(long answerId, string voteUid)
        {
            AnswerVoteDataLogic.Value.Add(new AnswerVote
            {
                AnswerId = answerId,
                Uid = voteUid,
                AddTime = DateTime.Now
            });
            //return AnswerVoteDataLogic.Value.AddAsync(new AnswerVote
            //{
            //    AnswerId = answerId,
            //    Uid = voteUid,
            //    AddTime = DateTime.Now
            //});
        }

        public static void VoteCancel(long answerId, string voteUid)
        {
            AnswerVoteDataLogic.Value.Delete(new AnswerVote
            {
                AnswerId = answerId,
                Uid = voteUid,
                AddTime = DateTime.Now
            });
            //return AnswerVoteDataLogic.Value.DeleteAsync(new AnswerVote
            //{
            //    AnswerId = answerId,
            //    Uid = voteUid,
            //    AddTime = DateTime.Now
            //});
        }

        public static void VoteDown(long answerId, string voteDownUid)
        {
            AnswerVoteDownDataLogic.Value.Add(new AnswerVoteDown
            {
                AnswerId = answerId,
                Uid = voteDownUid,
                AddTime = DateTime.Now
            });
            //return AnswerVoteDownDataLogic.Value.AddAsync(new AnswerVoteDown
            //{
            //    AnswerId = answerId,
            //    Uid = voteDownUid,
            //    AddTime = DateTime.Now
            //});
        }

        public static void VoteDownCancel(long answerId, string voteDownUid)
        {
            AnswerVoteDownDataLogic.Value.Delete(new AnswerVoteDown
            {
                AnswerId = answerId,
                Uid = voteDownUid,
                AddTime = DateTime.Now
            });
            //return AnswerVoteDownDataLogic.Value.DeleteAsync(new AnswerVoteDown
            //{
            //    AnswerId = answerId,
            //    Uid = voteDownUid,
            //    AddTime = DateTime.Now
            //});
        }
    }
}
