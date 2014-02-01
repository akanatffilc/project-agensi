using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IAnswerVoteRepository
    {
        AnswerVote[] FindByAnswerId(long answerId);

        AnswerVote[] FindByUserId(string userId);

        void Add(AnswerVote vote);

        void Delete(long answerId,string userId);

        Task AddAsync(AnswerVote vote);

        Task DeleteAsync(AnswerVote vote);

        int Save();

        Task<int> SaveAsync();
    }
}
