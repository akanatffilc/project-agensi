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

        public AnswerVoteDown[] FindByUid(string uid)
        {
            return context.AnswerVoteDowns.Where(x => x.Uid == uid).ToArray();
        }

        public void Add(AnswerVoteDown voteDown)
        {
            context.AnswerVoteDowns.Add(voteDown);
        }

        public void Delete(AnswerVoteDown voteDown)
        {
            var row = context.AnswerVoteDowns.Single(x => x.AnswerId == voteDown.AnswerId && x.Uid == voteDown.Uid);
            context.AnswerVoteDowns.Remove(row);
        }

        public async Task AddAsync(AnswerVoteDown voteDown)
        {
            await Task.Run(() =>
                {
                    context.AnswerVoteDowns.Add(voteDown);
                });
        }

        public async Task DeleteAsync(AnswerVoteDown voteDown)
        {
            await Task.Run(() =>
                {
                    var row = context.AnswerVotes.Single(x => x.AnswerId == voteDown.AnswerId && x.Uid == voteDown.Uid);
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
