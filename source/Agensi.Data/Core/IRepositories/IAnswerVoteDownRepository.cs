using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IAnswerVoteDownRepository
    {
        AnswerVoteDown[] FindByAnswerId(long answerId);

        AnswerVoteDown[] FindByUserId(string userId);

        void Add(AnswerVoteDown voteDown);

        void Delete(AnswerVoteDown voteDown);

        Task AddAsync(AnswerVoteDown voteDown);

        Task DeleteAsync(AnswerVoteDown voteDown);

        int Save();

        Task<int> SaveAsync();
    }
}
