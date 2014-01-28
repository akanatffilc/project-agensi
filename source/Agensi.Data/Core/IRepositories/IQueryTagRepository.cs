using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IQueryTagRepository
    {
        QueryTag[] FindByQueryId(long queryId);

        QueryTag[] FindByTagName(string tagName);

        void Add(QueryTag queryTag);

        void Delete(long queryId,string tagName);

        void Save();
    }
}
