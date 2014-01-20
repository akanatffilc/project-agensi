using Agensi.Core.Core;
using Agensi.Core.DataLogic.Core;
using Agensi.Core.Language;
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
        public static AgensiAnswer[] Create(AgensiQuery query)
        {
            return AnswerDataLogic.Value.FindByQueryId(query.QueryId).ToArray()
                .Select(x => new AgensiAnswer(x)).ToArray();
        }

        public static AgensiAnswer Create(long answerId)
        {
            var answer = AnswerDataLogic.Value.Find(answerId);
            if (answer != null)
                return new AgensiAnswer(answer);
            else
                return new AgensiAnswer(0);
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

        private static Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });
        private readonly Answer Answer;

        public long AnswerId { get { return Answer.AnswerId; } }
        public long QueryId { get { return Answer.QueryId; } }
        public string AnswerUid { get { return Answer.AnswerUid; } }
        private AgensiLanguage _agensiLanguage;
        public AgensiLanguage Language { get { return _agensiLanguage ?? (_agensiLanguage = new AgensiLanguage(Answer.LanguageId)); } }
        public string Text { get { return Answer.Text; } }
        public DateTime AnswerDate { get { return Answer.AnswerDate; } }
    }
}
