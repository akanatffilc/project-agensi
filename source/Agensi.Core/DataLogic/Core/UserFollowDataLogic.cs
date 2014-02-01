using Agensi.Data.Core;
using Agensi.Data.Core.IRepositories;
using Agensi.Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

        public int Add(UserFollow follow)
        {
            try
            {
                _repository.Add(follow);
                return _repository.Save();
            }
            catch
            {
                return 0;
            }
        }

        public int Delete(string userId, string followUserId)
        {
            try
            {
                _repository.Delete(userId, followUserId);
                return _repository.Save();
            }
            catch
            {
                return 0;
            }
        }
    }
}
