using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class QueryVoteDownRepository : IQueryVoteDownRepository
    {
        private AgensiDBEntities context;

        public QueryVoteDownRepository()
        {
            context = new AgensiDBEntities();
        }

        public QueryVoteDown[] FindByQueryId(long queryId)
        {
            return context.QueryVoteDowns.Where(x => x.QueryId == queryId).ToArray();
        }

        public QueryVoteDown[] FindByUserId(string userId)
        {
            return context.QueryVoteDowns.Where(x => x.UserId == userId).ToArray();
        }

        public void Add(QueryVoteDown voteDown)
        {
            context.QueryVoteDowns.Add(voteDown);
        }

        public void Delete(QueryVoteDown voteDown)
        {
            var row = context.QueryVoteDowns.Single(x => x.QueryId == voteDown.QueryId && x.UserId == voteDown.UserId);
            context.QueryVoteDowns.Remove(row);
        }

        public Task AddAsync(QueryVoteDown voteDown)
        {
            return Task.Run(() =>
                {
                    context.QueryVoteDowns.Add(voteDown);
                });
        }

        public Task DeleteAsync(QueryVoteDown voteDown)
        {
            return Task.Run(() =>
            {
                var row = context.QueryVoteDowns.Single(x => x.QueryId == voteDown.QueryId && x.UserId == voteDown.UserId);
                context.QueryVoteDowns.Remove(row);
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
