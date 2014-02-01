using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IAnswerRepository
    {
        Answer Find(long answerId);

        Answer[] FindByQueryId(long queryId);

        Answer[] FindByAnswerUserId(string userId);

        void Add(Answer answer);

        void Update(Answer answer);

        int Save();
    }
}
