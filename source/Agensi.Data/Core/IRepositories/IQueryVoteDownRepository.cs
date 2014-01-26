using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IQueryVoteDownRepository
    {
        QueryVoteDown[] FindByQueryId(long queryId);

        QueryVoteDown[] FindByUserId(string userId);

        void Add(QueryVoteDown voteDown);

        void Delete(QueryVoteDown voteDown);

        Task AddAsync(QueryVoteDown voteDown);

        Task DeleteAsync(QueryVoteDown voteDown);

        void Save();

        Task SaveAsync();

    }
}
