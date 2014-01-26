using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private AgensiDBEntities context;

        public AnswerRepository()
        {
            context = new AgensiDBEntities();
        }

        public Answer Find(long answerId)
        {
            return context.Answers.Find(answerId);
        }

        public Answer[] FindByQueryId(long queryId)
        {
            return context.Answers
                .Where(x => x.QueryId == queryId).ToArray();
        }

        public Answer[] FindByAnswerUserId(string userId)
        {
            return context.Answers
                .Where(x => x.AnswerUserId == userId).ToArray();
        }

        public void Add(Answer answer)
        {
            context.Answers.Add(answer);
        }

        public void Update(Answer answer)
        {
            context.Answers.Attach(answer);
            context.Entry<Answer>(answer).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
