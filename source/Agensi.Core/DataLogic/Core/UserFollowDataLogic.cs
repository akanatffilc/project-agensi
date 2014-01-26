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
    public class UserFollowDataLogic
    {
        private IUserFollowRepository _repository;

        public UserFollowDataLogic() : this(new UserFollowRepository()) { }

        public UserFollowDataLogic(IUserFollowRepository repository)
        {
            _repository = repository;
        }

        public UserFollow[] FindByUserId(string userId)
        {
            return _repository.FindByUserId(userId);
        }

        public UserFollow[] FindByFollowUserId(string userId)
        {
            return _repository.FindByFollowUserId(userId);
        }

        public void Add(UserFollow follow)
        {
            _repository.Add(follow);
            _repository.Save();
        }

        public void Delete(string userId, string followUserId)
        {
            _repository.Delete(userId, followUserId);
            _repository.Save();
        }
    }
}
