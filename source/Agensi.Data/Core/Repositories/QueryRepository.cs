using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class QueryRepository : IQueryRepository
    {
        private AgensiDBEntities context;

        public QueryRepository()
        {
            context = new AgensiDBEntities();
        }

        public Query Find(long queryId)
        {
            return context.Queries.Find(queryId);
        }

        public Query[] FindAll()
        {
            return context.Queries.ToArray();
        }

        public Query[] FindByOwnerUid(string uid)
        {
            return context.Queries.Where(x => x.OwnerUid == uid).ToArray();
        }

        public void Add(Query query)
        {
            context.Queries.Add(query);
        }

        public void Update(Query query)
        {
            context.Queries.Attach(query);
            context.Entry<Query>(query).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
