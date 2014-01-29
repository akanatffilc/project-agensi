using Agensi.Data.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Data.Core.Repositories
{
    public class QueryTagRepository : IQueryTagRepository
    {
        private AgensiDBEntities context;

        public QueryTagRepository()
        {
            context = new AgensiDBEntities();
        }


        public QueryTag[] FindByQueryId(long queryId)
        {
            return context.QueryTags.Where(x => x.QueryId == queryId).ToArray();
        }

        public QueryTag[] FindByTagName(string tagName)
        {
            return context.QueryTags.Where(x => x.TagName == tagName).ToArray();
        }

        public void Add(QueryTag queryTag)
        {
            context.QueryTags.Add(queryTag);
        }


        public void Delete(long queryId,string tagName)
        {
            var row = context.QueryTags.FirstOrDefault(x => x.QueryId == queryId && x.TagName == tagName);
            if (row != null)
                context.QueryTags.Remove(row);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
