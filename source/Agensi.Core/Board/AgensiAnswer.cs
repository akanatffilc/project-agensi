using Agensi.Core.Core;
using Agensi.Core.DataLogic.Core;
using Agensi.Core.Language;
using Agensi.Core.User;
using Agensi.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Board
{
    public class AgensiAnswer
    {
        public static AgensiAnswer Create(long answerId)
        {
            return new AgensiAnswer(answerId);
        }

        #region Constructor
        protected AgensiAnswer(Answer answer)
        {
            Answer = answer;
        }
        protected AgensiAnswer(long answerId)
        {
            Answer = AnswerDataLogic.Value.Find(answerId);
        }
        #endregion

        private Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });
        private Lazy<AnswerVoteDataLogic> AnswerVoteDataLogic = new Lazy<AnswerVoteDataLogic>(() => { return new AnswerVoteDataLogic(); });
        private Lazy<AnswerVoteDownDataLogic> AnswerVoteDownDataLogic = new Lazy<AnswerVoteDownDataLogic>(() => { return new AnswerVoteDownDataLogic(); });
        private readonly Answer Answer;

        private AgensiUser _answerUser;
        public AgensiUser AnswerUser { get { return _answerUser ?? (_answerUser = AgensiUser.Create(Answer.AnswerUserId)); } }
        public long QueryId { get { return Answer.QueryId; } }
        public long AnswerId { get { return Answer.AnswerId; } }
        private AgensiLanguage _agensiLanguage;
        public AgensiLanguage Language { get { return _agensiLanguage ?? (_agensiLanguage = new AgensiLanguage(Answer.LanguageId)); } }
        public string Text { get { return Answer.Text; } }
        public DateTime AnswerDate { get { return Answer.AnswerDate; } }

        private AnswerVote[] _votes;
        public AnswerVote[] Votes { get { return _votes ?? (_votes = AnswerVoteDataLogic.Value.FindByAnswerId(Answer.AnswerId)); } }

        private AnswerVoteDown[] _voteDowns;
        public AnswerVoteDown[] VoteDowns { get { return _voteDowns ?? (_voteDowns = AnswerVoteDownDataLogic.Value.FindByAnswerId(Answer.AnswerId)); } }
    }
}
