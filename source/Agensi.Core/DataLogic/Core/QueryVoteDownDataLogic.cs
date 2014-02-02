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

        internal QueryVoteDownDataLogic() : this(new QueryVoteDownRepository()) { }

        internal QueryVoteDownDataLogic(IQueryVoteDownRepository repository)
        {
            _repository = repository;
        }

        public QueryVoteDown[] FindByQueryId(long queryId)
        {
            return _repository.FindByQueryId(queryId);
        }

        public int Add(QueryVoteDown voteDown)
        {
            try
            {
                _repository.Add(voteDown);
                return _repository.Save();

            }
            catch
            {
                return 0;
            }
        }

        public int Delete(QueryVoteDown voteDown)
        {
            try
            {
                _repository.Delete(voteDown);
                return _repository.Save();

            }
            catch
            {
                return 0;
            }
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
