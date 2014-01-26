using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IUserVoteRepository
    {
        UserVote[] FindByUserId(long userId);

        UserVote[] FindByVoteUserId(string voteUserId);

        Task AddAsync(UserVote vote);

        Task DeleteAsync(UserVote vote);

        void Save();

        Task SaveAsync();
    }
}
