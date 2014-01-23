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

        public QueryVote[] FindByUid(string uid)
        {
            return context.QueryVotes.Where(x => x.Uid == uid).ToArray();
        }

        public void Add(QueryVote vote)
        {
            context.QueryVotes.Add(vote);
        }

        public void Delete(QueryVote vote)
        {
            var row = context.QueryVotes.Single(x => x.QueryId == vote.QueryId && x.Uid == vote.Uid);
            context.QueryVotes.Remove(row);
        }

        public Task AddAsync(QueryVote vote)
        {
            throw new NotImplementedException();
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
