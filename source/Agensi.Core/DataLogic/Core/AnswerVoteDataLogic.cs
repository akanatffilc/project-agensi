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
            _repository.AddAsync(vote);
            return _repository.SaveAsync();
        }

        public Task DeleteAsync(AnswerVote vote)
        {
            return _repository.DeleteAsync(vote);
        }

        public void Add(AnswerVote vote)
        {
            _repository.Add(vote);
            _repository.Save();
        }

        public void Delete(AnswerVote vote)
        {
            _repository.Delete(vote);
            _repository.Save();
        }
    }
}
