using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.IRepositories
{
    public interface IQueryRepository
    {
        Query Find(long queryId);

        Query[] FindAll();

        Query[] FindByOwnerUid(string uid);

        void Add(Query query);

        void Update(Query query);

        void Save();
    }
}
