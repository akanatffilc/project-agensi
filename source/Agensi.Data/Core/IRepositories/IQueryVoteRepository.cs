using System;
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

        void Delete(long queryId,string userId);

        Task AddAsync(QueryVote vote);

        Task DeleteAsync(QueryVote vote);

        int Save();

        Task<int> SaveAsync();

    }
}
