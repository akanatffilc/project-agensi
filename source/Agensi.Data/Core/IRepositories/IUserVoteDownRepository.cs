using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IUserVoteDownRepository
    {
        UserVoteDown[] FindByUid(long uid);

        UserVoteDown[] FindByVoteDownUid(string voteDownUid);

        Task AddAsync(UserVoteDown voteDown);

        Task DeleteAsync(UserVoteDown voteDown);

        void Save();

        Task SaveAsync();


    }
}
