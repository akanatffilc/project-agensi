using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IQueryViewRepository
    {
        QueryView[] FindByQueryId(long queryId);

        void Add(QueryView queryView);

        int Save();    
    }
}
