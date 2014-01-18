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

        AnswerVote[] FindByUid(string uid);

        Task AddAsync(AnswerVote vote);

        Task DeleteAsync(AnswerVote vote);

        void Save();
    }
}
