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
    public class AnswerDataLogic
    {
        private IAnswerRepository _repository;

        public AnswerDataLogic() : this(new AnswerRepository()) { }

        public AnswerDataLogic(IAnswerRepository repository) 
        {
            _repository = repository;
        }

        public Answer Find(long answerId)
        {
            return _repository.Find(answerId);
        }

        public Answer[] FindByQueryId(long queryId)
        {
            return _repository.FindByQueryId(queryId);
        }

        public void Add(Answer answer)
        {
            _repository.Add(answer);
            _repository.Save();
        }
    }
}
