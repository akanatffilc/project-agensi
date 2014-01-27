using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class QueryViewRepository : IQueryViewRepository
    {
        private AgensiDBEntities context;

        public QueryViewRepository()
        {
            context = new AgensiDBEntities();
        }


        public QueryView[] FindByQueryId(long queryId)
        {
            return context.QueryViews.Where(x => x.QueryId == queryId).ToArray();
        }

        public void Add(QueryView queryView)
        {
            context.QueryViews.Add(queryView);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
