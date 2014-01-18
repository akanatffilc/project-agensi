using Agensi.Core.DataLogic.Core;
using Agensi.Data.Core;
using Agensi.Data.Core.IRepositories;
using Agensi.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.Board
{
    public class AgensiQuery
    {
        private Lazy<QueryDataLogic> QueryDataLogic = new Lazy<QueryDataLogic>(() => { return new QueryDataLogic(); });
        private Lazy<AnswerDataLogic> AnswerDataLogic = new Lazy<AnswerDataLogic>(() => { return new AnswerDataLogic(); });

        public Query Query { get; private set; }
        public Answer[] Answers { get; private set; }

        public AgensiQuery(long queryId)
        {
            Query = QueryDataLogic.Value.Find(queryId);
            Answers = AnswerDataLogic.Value.FindByQueryId(queryId);
        }
    }
}
