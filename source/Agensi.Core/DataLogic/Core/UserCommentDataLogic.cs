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
    public class UserCommentDataLogic
    {
        private IUserCommentRepository _repository;

        public UserCommentDataLogic() : this(new UserCommentRepository()) { }

        public UserCommentDataLogic(IUserCommentRepository repository) 
        {
            _repository = repository;
        }

        public UserComment[] FindByFromUserId(string userId)
        {
            return _repository.FindByFromUserId(userId);
        }

        public UserComment[] FindByToUserId(string userId)
        {
            return _repository.FindByToUserId(userId);
        }

        public void Add(UserComment userComment)
        {
            _repository.Add(userComment);
            _repository.Save();
        }

        public void Delete(long commentId)
        {
            _repository.Delete(commentId);
            _repository.Save();
        }

        public void UpdateViewFlag(long commentId,int viewFlag)
        {
            _repository.UpdateViewFlag(commentId, viewFlag);
            _repository.Save();
        }
    }
}
