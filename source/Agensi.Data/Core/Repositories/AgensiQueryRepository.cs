using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class AgensiQueryRepository : IAgensiQueryRepository
    {
        private AgensiDBEntities context;

        public AgensiQueryRepository()
        {
            context = new AgensiDBEntities();
        }

        public AgensiQuery Find(long queryId)
        {
            return context.AgensiQueries.Find(queryId);
        }

        public AgensiQuery[] FindByOwnerUid(string uid)
        {
            return context.AgensiQueries.Where(x => x.OwnerUid == uid).ToArray();
        }

        public void Add(AgensiQuery query)
        {
            context.AgensiQueries.Add(query);
        }

        public void Update(AgensiQuery query)
        {
            context.AgensiQueries.Attach(query);
            context.Entry<AgensiQuery>(query).State = EntityState.Modified;
        }

    }
}
