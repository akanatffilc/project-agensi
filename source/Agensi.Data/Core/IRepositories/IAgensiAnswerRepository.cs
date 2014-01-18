using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IAgensiAnswerRepository
    {
        AgensiAnswer Find(long answerId);

        AgensiAnswer[] FindByQueryId(long queryId);

        void Add(AgensiAnswer answer);

        void Update(AgensiAnswer answer);
    }
}
