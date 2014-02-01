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
            return _repository.AddAsync(voteDown)
                .ContinueWith((prevTask) =>
                {
                    _repository.Save();
                });
        }

        public Task DeleteAsync(AnswerVoteDown voteDown)
        {
            return _repository.DeleteAsync(voteDown)
                .ContinueWith((prevTask) =>
                {
                    _repository.Save();
                });
        }

        public int Add(AnswerVoteDown voteDown)
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

        public int Delete(AnswerVoteDown voteDown)
        {
            try
            {
                _repository.Delete(voteDown);
                return _repository.Save();
            }
            catch { return 0; }
        }
    }
}
