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

        internal QueryVoteDataLogic() : this(new QueryVoteRepository()) { }

        internal QueryVoteDataLogic(IQueryVoteRepository repository)
        {
            _repository = repository;
        }

        public QueryVote[] FindByQueryId(long queryId)
        {
            return _repository.FindByQueryId(queryId);
        }

        public int Add(QueryVote vote)
        {
            try
            {
                _repository.Add(vote);
                return _repository.Save();
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(long queryId,string userId)
        {
            try
            {
                _repository.Delete(queryId, userId);
                return _repository.Save();
            }
            catch
            {
                return 0;
            }
        }

        public Task AddAsync(QueryVote vote)
        {
            return _repository.AddAsync(vote)
                .ContinueWith((prevTask) =>
                {
                    _repository.SaveAsync();
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
