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
        private static Lazy<QueryDataLogic> QueryDataLogic = new Lazy<QueryDataLogic>(() => { return new QueryDataLogic(); });
        private static Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });

        internal BoardManager(AgensiUser user)
        {
            _user = user;
        }

        private AgensiUser _user;

        public AgensiAnswerCommands CreateAnswerCommands(AgensiAnswer answer)
        {
            return new AgensiAnswerCommands(_user, answer);
        }

        public AgensiQueryCommands CreateQueryCommands(AgensiQuery query)
        {
            return new AgensiQueryCommands(_user, query);
        }

        public AgensiQuery[] FindQueryAll()
        {
            return QueryDataLogic.Value.FindAll().Select(x => AgensiQuery.Create(x.QueryId)).ToArray();
        }

        public void AddQuery(Query query)
        {
            QueryDataLogic.Value.Add(query);
        }

        public void AddAnswer(Answer answer)
        {
            AnswerDataLogic.Value.Add(answer);
        }
    }
}
