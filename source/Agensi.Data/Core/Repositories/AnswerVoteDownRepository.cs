using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class AnswerVoteDownRepository : IAnswerVoteDownRepository
    {
        private AgensiDBEntities context;

        public AnswerVoteDownRepository()
        {
            context = new AgensiDBEntities();
        }

        public AnswerVoteDown[] FindByAnswerId(long answerId)
        {
            return context.AnswerVoteDowns.Where(x => x.AnswerId == answerId).ToArray();
        }

        public AnswerVoteDown[] FindByUserId(string userId)
        {
            return context.AnswerVoteDowns.Where(x => x.UserId == userId).ToArray();
        }

        public void Add(AnswerVoteDown voteDown)
        {
            context.AnswerVoteDowns.Add(voteDown);
        }

        public void Delete(AnswerVoteDown voteDown)
        {
            var row = context.AnswerVoteDowns.Single(x => x.AnswerId == voteDown.AnswerId && x.UserId == voteDown.UserId);
            context.AnswerVoteDowns.Remove(row);
        }

        public Task AddAsync(AnswerVoteDown voteDown)
        {
            return Task.Run(() =>
                {
                    context.AnswerVoteDowns.Add(voteDown);
                });
        }

        public Task DeleteAsync(AnswerVoteDown voteDown)
        {
            return Task.Run(() =>
                {
                    var row = context.AnswerVotes.Single(x => x.AnswerId == voteDown.AnswerId && x.UserId == voteDown.UserId);
                    context.AnswerVoteDowns.Remove(voteDown);
                });
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
