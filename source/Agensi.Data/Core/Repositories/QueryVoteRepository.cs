using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class QueryVoteRepository : IQueryVoteRepository
    {
        private AgensiDBEntities context;

        public QueryVoteRepository()
        {
            context = new AgensiDBEntities();
        }

        public QueryVote[] FindByQueryId(long queryId)
        {
            return context.QueryVotes.Where(x => x.QueryId == queryId).ToArray();
        }

        public QueryVote[] FindByUserId(string userId)
        {
            return context.QueryVotes.Where(x => x.UserId == userId).ToArray();
        }

        public void Add(QueryVote vote)
        {
            context.QueryVotes.Add(vote);
        }

        public void Delete(QueryVote vote)
        {
            var row = context.QueryVotes.Single(x => x.QueryId == vote.QueryId && x.UserId == vote.UserId);
            context.QueryVotes.Remove(row);
        }

        public async Task AddAsync(QueryVote vote)
        {
            await Task.Run(() =>
            {
                context.QueryVotes.Add(vote);
                context.SaveChangesAsync();
            });
        }

        public Task DeleteAsync(QueryVote vote)
        {
            throw new NotImplementedException();
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
