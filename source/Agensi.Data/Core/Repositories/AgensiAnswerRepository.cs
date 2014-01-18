using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class AgensiAnswerRepository : IAgensiAnswerRepository
    {
        private AgensiDBEntities context;

        public AgensiAnswerRepository()
        {
            context = new AgensiDBEntities();
        }

        public AgensiAnswer Find(long answerId)
        {
            return context.AgensiAnswers.Find(answerId);
        }

        public AgensiAnswer[] FindByQueryId(long queryId)
        {
            return context.AgensiAnswers
                .Where(x => x.QueryId == queryId).ToArray();
        }

        public void Add(AgensiAnswer answer)
        {
            context.AgensiAnswers.Add(answer);
        }

        public void Update(AgensiAnswer answer)
        {
            context.AgensiAnswers.Attach(answer);
            context.Entry<AgensiAnswer>(answer).State = EntityState.Modified;
        }
    }
}
