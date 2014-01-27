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
    public class QueryViewDataLogic
    {
        private IQueryViewRepository _repository;

        public QueryViewDataLogic() : this(new QueryViewRepository()) { }

        public QueryViewDataLogic(IQueryViewRepository repository)
        {
            _repository = repository;
        }

        public QueryView[] FindByQueryId(long queryId)
        {
            return _repository.FindByQueryId(queryId);
        }

        public void Add(QueryView queryView)
        {
            try
            {
                _repository.Add(queryView);
                _repository.Save();
            }
            catch { }
        }
    }
}
