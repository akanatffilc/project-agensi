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
    public class AnswerVoteDownDataLogic
    {
        private IAnswerVoteDownRepository _repository;

        public AnswerVoteDownDataLogic() : this(new AnswerVoteDownRepository()) { }

        public AnswerVoteDownDataLogic(IAnswerVoteDownRepository repository) 
        {
            _repository = repository;
        }

        public AnswerVoteDown[] FindByAnswerId(long answerId)
        {
            return _repository.FindByAnswerId(answerId);
        }

        public Task AddAsync(AnswerVoteDown voteDown)
        {
            return _repository.AddAsync(voteDown);
        }

        public Task DeleteAsync(AnswerVoteDown voteDown)
        {
            return _repository.DeleteAsync(voteDown);
        }

        public void Add(AnswerVoteDown voteDown)
        {
            _repository.Add(voteDown);
            _repository.Save();
        }

        public void Delete(AnswerVoteDown voteDown)
        {
            _repository.Delete(voteDown);
            _repository.Save();
        }
    }
}
