using Agensi.Data.Core;
using Agensi.Data.Core.IRepositories;
using Agensi.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agensi.Core.DataLogic.Core
{
    public class QueryTagDataLogic
    {
        private IQueryTagRepository _repository;

        public QueryTagDataLogic() : this(new QueryTagRepository()) { }

        public QueryTagDataLogic(IQueryTagRepository repository)
        {
            _repository = repository;
        }

        public QueryTag[] FindByQueryId(long queryId)
        {
            return _repository.FindByQueryId(queryId);
        }

        public QueryTag[] FindByTagName(string tagName)
        {
            return _repository.FindByTagName(tagName);
        }

        public void Add(QueryTag queryTag)
        {
            _repository.Add(queryTag);
            _repository.Save();
        }

        public void Delete(long queryId,string tagName)
        {
            _repository.Delete(queryId, tagName);
            _repository.Save();
        }

    }
}
