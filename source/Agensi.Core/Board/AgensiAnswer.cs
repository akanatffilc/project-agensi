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
            _answer = answer;
        }
        protected AgensiAnswer(long answerId)
        {
            _answer = AnswerDataLogic.Value.Find(answerId);
        }
        #endregion

        private Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });
        private Lazy<AnswerVoteDataLogic> AnswerVoteDataLogic = new Lazy<AnswerVoteDataLogic>(() => { return new AnswerVoteDataLogic(); });
        private Lazy<AnswerVoteDownDataLogic> AnswerVoteDownDataLogic = new Lazy<AnswerVoteDownDataLogic>(() => { return new AnswerVoteDownDataLogic(); });
        private readonly Answer _answer;

        public bool IsExists
        {
            get { return _answer != null; }
        }

        private AgensiUser _answerUser;
        public AgensiUser AnswerUser { get { return _answerUser ?? (_answerUser = AgensiUser.Create(_answer.AnswerUserId)); } }
        public long QueryId { get { return _answer.QueryId; } }
        public long AnswerId { get { return _answer.AnswerId; } }
        private AgensiLanguage _agensiLanguage;
        public AgensiLanguage Language { get { return _agensiLanguage ?? (_agensiLanguage = new AgensiLanguage(_answer.LanguageId)); } }
        public string Text { get { return _answer.Text; } }
        public DateTime AnswerDate { get { return _answer.AnswerDate; } }

        private AnswerVote[] _votes;
        public AnswerVote[] Votes { get { return _votes ?? (_votes = AnswerVoteDataLogic.Value.FindByAnswerId(_answer.AnswerId)); } }

        public long? PallentAnswerId { get { return _answer.ParentAnswerId; } }

        #region Methods

        public bool IsVoted(string userId)
        {
            return Votes.Any(x => x.UserId == userId);
        }

        #endregion

    }
}
