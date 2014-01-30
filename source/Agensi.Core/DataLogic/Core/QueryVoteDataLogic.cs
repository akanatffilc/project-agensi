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
    public class QueryVoteDataLogic
    {
        private IQueryVoteRepository _repository;

        public QueryVoteDataLogic() : this(new QueryVoteRepository()) { }

        public QueryVoteDataLogic(IQueryVoteRepository repository) 
        {
            _repository = repository;
        }

        public QueryVote[] FindByQueryId(long queryId)
        {
            return _repository.FindByQueryId(queryId);
        }

        public void Add(QueryVote vote)
        {
            _repository.Add(vote);
            _repository.Save();
        }

        public void Delete(QueryVote vote)
        {
            _repository.Delete(vote);
            _repository.Save();
        }

        public Task AddAsync(QueryVote vote)
        {
            return _repository.AddAsync(vote)
                .ContinueWith((prevTask) =>
                {
                    _repository.Save();
                });
        }

        public Task DeleteAsync(QueryVote vote)
        {
            return _repository.DeleteAsync(vote)
                .ContinueWith((prevTask) =>
                {
                    _repository.Save();
                });
        }

    }
}
