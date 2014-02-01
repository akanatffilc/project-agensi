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
    public class AnswerVoteDataLogic
    {
        private IAnswerVoteRepository _repository;

        public AnswerVoteDataLogic() : this(new AnswerVoteRepository()) { }

        public AnswerVoteDataLogic(IAnswerVoteRepository repository) 
        {
            _repository = repository;
        }

        public AnswerVote[] FindByAnswerId(long answerId)
        {
            return _repository.FindByAnswerId(answerId);
        }

        public Task AddAsync(AnswerVote vote)
        {
            return _repository.AddAsync(vote)
                .ContinueWith((prevTask) => {
                    _repository.Save();
                });
        }

        public Task DeleteAsync(AnswerVote vote)
        {
            return _repository.DeleteAsync(vote)
                .ContinueWith((prevTask) =>
                {
                    _repository.Save();
                });
        }

        public int Add(AnswerVote vote)
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

        public int Delete(AnswerVote vote)
        {
            try
            {
                _repository.Delete(vote);
                return _repository.Save();
            }
            catch
            {
                return 0;
            }
        }
    }
}
