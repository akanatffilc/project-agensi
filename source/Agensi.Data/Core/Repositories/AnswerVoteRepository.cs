using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class AnswerVoteRepository : IAnswerVoteRepository
    {
        private AgensiDBEntities context;

        public AnswerVoteRepository()
        {
            context = new AgensiDBEntities();
        }

        public AnswerVote[] FindByAnswerId(long answerId)
        {
            return context.AnswerVotes.Where(x => x.AnswerId == answerId).ToArray();
        }

        public AnswerVote[] FindByUid(string uid)
        {
            return context.AnswerVotes.Where(x => x.Uid == uid).ToArray();
        }

        public async Task AddAsync(AnswerVote vote)
        {
            await Task.Run(() =>
                {
                    context.AnswerVotes.Add(vote);
                });
        }

        public async Task DeleteAsync(AnswerVote vote)
        {
            await Task.Run(() =>
                {
                    context.AnswerVotes.Attach(vote);
                    context.Entry<AnswerVote>(vote).State = EntityState.Modified;
                });
        }

    }
}
