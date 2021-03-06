﻿using Agensi.Data.Core.IRepositories;
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

        public void Delete(long queryId,string userId)
        {
            var row = context.QueryVotes.Single(x => x.QueryId == queryId && x.UserId == userId);
            context.QueryVotes.Remove(row);
        }

        public  Task AddAsync(QueryVote vote)
        {
            return Task.Run(() =>
            {
                context.QueryVotes.Add(vote);
            });
        }

        public Task DeleteAsync(QueryVote vote)
        {
            return Task.Run(() =>
            {
                var row = context.QueryVotes.Single(x => x.QueryId == vote.QueryId && x.UserId == vote.UserId);
                context.QueryVotes.Remove(row);
            });
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
