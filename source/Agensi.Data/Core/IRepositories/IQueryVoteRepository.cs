﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IQueryVoteRepository
    {
        QueryVote[] FindByQueryId(long queryId);

        QueryVote[] FindByUserId(string userId);

        void Add(QueryVote vote);

        void Delete(QueryVote vote);

        Task AddAsync(QueryVote vote);

        Task DeleteAsync(QueryVote vote);

        void Save();

        Task SaveAsync();

    }
}