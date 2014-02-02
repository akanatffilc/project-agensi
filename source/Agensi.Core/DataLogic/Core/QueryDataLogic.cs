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
    public class QueryDataLogic
    {
        private IQueryRepository _repository;

        internal QueryDataLogic() : this(new QueryRepository()) { }

        internal QueryDataLogic(IQueryRepository repository) 
        {
            _repository = repository;
        }

        public Query Find(long queryId)
        {
            return _repository.Find(queryId);
        }

        public Query[] FindAll()
        {
            return _repository.FindAll();
        }

        public Query[] FindByOwnerId(string uid)
        {
            return _repository.FindByOwnerUserId(uid);
        }


        public int Add(Query query)
        {
            try
            {
                _repository.Add(query);
                return _repository.Save();
            }
            catch
            {
                return 0;
            }
        }
    }
}
