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
    }
}
