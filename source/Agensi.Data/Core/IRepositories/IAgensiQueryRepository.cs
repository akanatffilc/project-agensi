using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IAgensiQueryRepository
    {
        AgensiQuery Find(long queryId);

        AgensiQuery[] FindByOwnerUid(string uid);

        void Add(AgensiQuery query);

        void Update(AgensiQuery query);
    }
}
