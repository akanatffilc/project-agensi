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
    }
}
