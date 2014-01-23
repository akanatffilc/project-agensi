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

        public QueryVoteDown[] FindByUid(string uid)
        {
            return context.QueryVoteDowns.Where(x => x.Uid == uid).ToArray();
        }

        public void Add(QueryVoteDown voteDown)
        {
            context.QueryVoteDowns.Add(voteDown);
        }

        public void Delete(QueryVoteDown voteDown)
        {
            var row = context.QueryVoteDowns.Single(x => x.QueryId == voteDown.QueryId && x.Uid == voteDown.Uid);
            context.QueryVoteDowns.Remove(row);
        }

        public Task AddAsync(QueryVoteDown voteDown)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(QueryVoteDown voteDown)
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
