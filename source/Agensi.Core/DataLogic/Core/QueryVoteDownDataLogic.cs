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
    public class QueryVoteDownDataLogic
    {
        private IQueryVoteDownRepository _repository;

        public QueryVoteDownDataLogic() : this(new QueryVoteDownRepository()) { }

        public QueryVoteDownDataLogic(IQueryVoteDownRepository repository) 
        {
            _repository = repository;
        }

        public QueryVoteDown[] FindByQueryId(long queryId)
        {
            return _repository.FindByQueryId(queryId);
        }

        public void Add(QueryVoteDown voteDown)
        {
            _repository.Add(voteDown);
            _repository.Save();
        }

        public void Delete(QueryVoteDown voteDown)
        {
            _repository.Delete(voteDown);
            _repository.Save();
        }

        public Task AddAsync(QueryVoteDown voteDown)
        {
            return _repository.AddAsync(voteDown)
                .ContinueWith((prevTask) =>
                {
                    _repository.Save();
                });
        }

        public Task DeleteAsync(QueryVoteDown voteDown)
        {
            return _repository.DeleteAsync(voteDown)
                .ContinueWith((prevTask) =>
                {
                    _repository.Save();
                });
        }

    }
}
